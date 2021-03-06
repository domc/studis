﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using studis.Models;
using System.Web.Security;

namespace studis.Controllers
{
    public class KartotecniListController : Controller
    {
        public studisEntities db = new studisEntities();

        // GET: KartotecniList
        [Authorize(Roles = "Referent, Študent, Profesor")]
        public ActionResult Izpis(int? id)
        {
            // akcija za referenta
            if (User.IsInRole("Referent") || User.IsInRole("Profesor"))
            {
                if (id != null)
                {
                    ViewBag.Vpisna = id;
                    ViewBag.Student = db.students.Where(s => s.vpisnaStevilka == id).First();
                    return View();
                }
                else
                {
                    TempData["Napaka"] = "Izbran ni bil noben študent!";
                    RedirectToAction("Napaka");
                }
            }
            else if (User.IsInRole("Študent"))
            {
                try
                {
                    // pridobi študenta
                    UserHelper uh = new UserHelper();
                    var student = uh.FindByName(User.Identity.Name).students.FirstOrDefault();

                    ViewBag.Student = db.students.Where(s => s.vpisnaStevilka == student.vpisnaStevilka).First();
                    ViewBag.Vpisna = student.vpisnaStevilka;
                    return View();
                }
                catch
                {
                    TempData["Napaka"] = "Študent nima vzpostavljenega nobenega izvajanja!";
                    RedirectToAction("Napaka");
                }
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Referent, Študent, Profesor")]
        public ActionResult Izpis(int vpisna, string polaganja)
        {
            ViewBag.Vpisna = vpisna;
            ViewBag.Student = db.students.Where(s => s.vpisnaStevilka == vpisna).First();

            // samo zadnje polaganje
            if (polaganja == "Zadnje polaganje")
            {
                // pridobi vse vpisne liste za študenta, kjer je študijski program = selected
                var vpisi = db.vpis.Where(v => v.vpisnaStevilka == vpisna).Include(a => a.izvajanjes).ToList();
                ViewBag.Vpisi = vpisi;

                // preveri če je ponavljanje
                var ponavljanje = vpisi.Where(v => v.vrstaVpisa == 2 || v.vrstaVpisa == 3);
                List<int> vpisnaId = new List<int>();
                if (ponavljanje.Count() > 0)
                {
                    var letnikPon = Convert.ToInt32(ponavljanje.Select(p => p.letnikStudija).FirstOrDefault());
                    
                    foreach(var v in vpisi.Where(v => v.letnikStudija == letnikPon))
                    {
                        vpisnaId.Add(v.id);
                    }
                    var tn = vpisnaId.First();
                    ViewBag.Zacasni = db.vpis.Where(v => v.id == tn).FirstOrDefault();
                }
                

                // pridobi izvajanja
                List<izvajanje> izvajanja = new List<izvajanje>();

                foreach (var vpis in vpisi) 
                {
                    foreach (var izv in vpis.izvajanjes.ToList())
                    {
                        if (izv != null)
                        {
                            izvajanja.Add(izv);
                        }
                    }
                }
                ViewBag.Izvajanja = izvajanja;

                // pridobi in vrni izpitne roke, ki so bili (zadnji) opravljani
                List<izpitnirok> roki = new List<izpitnirok>();

                foreach (var izv in izvajanja)
                {
                    foreach(var r in izv.izpitniroks.OrderByDescending(r => r.datum).ToList())
                    {
                        roki.Add(r);
                    }
                }

                ViewBag.Roki = roki;

                // pridobi opravljanja izpitov
                List<prijavanaizpit> prijave = new List<prijavanaizpit>();

                foreach (var r in roki.OrderByDescending(r => r.datum).ToList())
                {
                    foreach (var p in r.prijavanaizpits.Where(p => p.stanje == 2))
                    {
                        if (p.ocenas != null)
                        {
                            prijave.Add(p);
                        }
                    }       
                }
                ViewBag.Prijave = prijave;

                // zadnje opravljanje
                ViewBag.Izbira = 0;

                // vrni modula, ko je študent v 3. letniku BUNI
                try
                {
                    var vm = db.vpis.Where(v => v.vpisnaStevilka == vpisna && v.letnikStudija == 3).FirstOrDefault();

                    List<int> moduli = new List<int>();
                            
                    foreach (var i in vm.izvajanjes)
                    {
                        if (i.predmet.modul != null)
                        {
                            moduli.Add(Convert.ToInt32(i.predmet.modul.id));
                        }
                    }

                    var unique = moduli.Distinct();

                    List<string> final = new List<string>();
                        
                    foreach (var u in unique)
                    {
                        if (moduli.Count(item => item == Convert.ToInt32(u)) > 1)
                        {
                            final.Add(vm.izvajanjes.Where(i => i.predmet.modulId == u).Select(i => i.predmet.modul.ime).First());
                        }
                    }
                        
                    ViewBag.Moduli = final;
                }
                catch { }
            } 

            // vsa polaganja
            else
            {
                // pridobi vse vpisne liste za študenta, kjer je študijski program = selected
                var vpisi = db.vpis.Where(v => v.vpisnaStevilka == vpisna).Include(v => v.izvajanjes).ToList();
                ViewBag.Vpisi = vpisi;

                // preveri če je ponavljanje
                var ponavljanje = vpisi.Where(v => v.vrstaVpisa == 2 || v.vrstaVpisa == 3);
                List<int> vpisnaId = new List<int>();
                if (ponavljanje.Count() > 0)
                {
                    var letnikPon = Convert.ToInt32(ponavljanje.Select(p => p.letnikStudija).FirstOrDefault());

                    foreach (var v in vpisi.Where(v => v.letnikStudija == letnikPon))
                    {
                        vpisnaId.Add(v.id);
                    }
                    var tn = vpisnaId.First();
                    ViewBag.Zacasni = db.vpis.Where(v => v.id == tn).FirstOrDefault();
                }

                // pridobi izvajanja
                List<izvajanje> izvajanja = new List<izvajanje>();

                foreach (var vpis in vpisi)
                {
                    foreach (var izv in vpis.izvajanjes.ToList())
                    {
                        if (izv != null)
                        {
                            izvajanja.Add(izv);
                        }
                    }
                }
                
                ViewBag.Izvajanja = izvajanja;

                // pridobi in vrni vse izpitni roke, ki so bili opravljani
                List<izpitnirok> roki = new List<izpitnirok>();
                
                foreach (var izv in izvajanja)
                {
                    foreach (var r in izv.izpitniroks.ToList())
                    {
                        if (r.prijavanaizpits.Where(p => p.stanje == 2).ToList() != null)
                        {
                            roki.Add(r);
                        }
                    }
                }
                
                ViewBag.Roki = roki;

                // pridobi opravljanja izpitov
                List<prijavanaizpit> prijave = new List<prijavanaizpit>();
                
                foreach (var r in roki)
                {
                    foreach (var p in r.prijavanaizpits.Where(p => p.stanje == 2).ToList())
                    {
                        if (p.ocenas != null)
                        {
                            prijave.Add(p);
                        }
                    }
                }
                
                ViewBag.Prijave = prijave;

                // vsa opravljanja
                ViewBag.Izbira = 1;

                // vrni modula, ko je študent v 3. letniku BUNI
                try
                {
                    var vm = db.vpis.Where(v => v.vpisnaStevilka == vpisna && v.letnikStudija == 3).Include(v => v.izvajanjes).FirstOrDefault();
                    List<int> moduli = new List<int>();
                        
                    foreach (var i in vm.izvajanjes)
                    {
                        if (i.predmet.modul != null)
                        {
                            moduli.Add(Convert.ToInt32(i.predmet.modul.id));
                        }
                    }
                        
                    var unique = moduli.Distinct();

                    List<string> final = new List<string>();
                        
                    foreach (var u in unique)
                    {
                        if (moduli.Count(item => item == Convert.ToInt32(u)) > 1)
                        {
                            final.Add(vm.izvajanjes.Where(i => i.predmet.modulId == u).Select(i => i.predmet.modul.ime).First());
                        }
                    }
                        
                    ViewBag.Moduli = final;
                }
                catch { }
            }

            return View();
        }

        [Authorize(Roles = "Referent, Študent, Profesor")]
        public ActionResult Napaka()
        {
            ViewBag.Message = TempData["Napaka"];
            return View();
        }
    }
}