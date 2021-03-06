﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using studis.Models;

namespace studis.Models
{
    public class Baza
    {       
 
        private studisEntities db;

        public Baza()
        {
            db = new studisEntities();
        }

        public VpisniListModel getVpisniList(int id)
        {
            vpi vpi = db.vpis.Where(a => a.id == id).First();
            student student = vpi.student;

            VpisniListModel vpisniList = new VpisniListModel();
            vpisniList.ime = student.ime;
            vpisniList.priimek = student.priimek;
            vpisniList.prenosniTelefon = student.prenosniTelefon;
            vpisniList.datumRojstva = student.datumRojstva;
            vpisniList.davcnaStevilka = student.davcnaStevilka ?? 00000000;
            vpisniList.emso = student.emso;
            vpisniList.email = student.email;
            vpisniList.krajRojstva = student.krajRojstva;
            vpisniList.obcinaRojstva = student.obcinaRojstva;
            vpisniList.drzavaRojstva = student.drzavaRojstva;
            vpisniList.drzavljanstvo = student.drzavljanstvo;
            
            vpisniList.vrocanje = student.vrocanje ?? default(bool);
            vpisniList.naslov = student.naslov;
            vpisniList.obcina = student.obcina;
            vpisniList.postnaStevilka = student.postnaStevilka;
            vpisniList.drzava = student.drzava;

            vpisniList.vrocanjeZacasni = student.vrocanjeZacasni ?? default(bool);
            vpisniList.naslovZacasni = student.naslovZacasni ?? default(string);
            vpisniList.obcinaZacasni = student.obcinaZacasni ?? default(int);
            vpisniList.postnaStevilkaZacasni = student.postnaStevilkaZacasni ?? default(int);
            vpisniList.drzavaZacasni = student.drzavaZacasni ?? default(int);
            
            vpisniList.studijskiProgram = vpi.studijskiProgram;
            vpisniList.smer = vpi.smer ?? default(int);
            vpisniList.krajIzvajanja = vpi.krajIzvajanja;
            vpisniList.izbirnaSkupina = vpi.izbirnaSkupina;
            vpisniList.studijskiProgram2 = vpi.studijskiProgram2 ?? default(int);
            vpisniList.smer2 = vpi.smer2 ?? default(int);
            vpisniList.krajIzvajanja2 = vpi.krajIzvajanja2 ?? default(int);
            vpisniList.izbirnaSkupina2 = vpi.izbirnaSkupina2 ?? default(int);
            vpisniList.vrstaStudija = vpi.vrstaStudija;
            vpisniList.vrstaVpisa = vpi.vrstaVpisa;
            vpisniList.letnikStudija = vpi.letnikStudija;
            vpisniList.nacinStudija = vpi.nacinStudija;
            vpisniList.oblikaStudija = vpi.oblikaStudija;
            vpisniList.studijskoLetoPrvegaVpisa = vpi.studijskoLetoPrvegaVpisa;
            vpisniList.soglasje1 = vpi.soglasje1 ?? default(bool);
            vpisniList.soglasje2 = vpi.soglasje2 ?? default(bool);
            vpisniList.dr_dan = vpi.student.datumRojstva.Day;
            vpisniList.dr_mesec = vpi.student.datumRojstva.Month;
            vpisniList.dr_leto = vpi.student.datumRojstva.Year;

            return vpisniList;
        }

        //my_aspnet_user
        public static VpisniListModel getVpisniListKandidat(my_aspnet_users user)
        {
            VpisniListModel vpisniList = new VpisniListModel();
            kandidat k = user.kandidats.First();

            vpisniList.ime = k.ime;
            vpisniList.priimek = k.priimek;
            vpisniList.email = k.email;
            vpisniList.studijskiProgram = k.studijskiProgram;
            vpisniList.letnikStudija = 1;

            return vpisniList;
        }

        //vpi id
        public VpisniListModel getVpisniListEdit(int id)
        {
            vpi vpi = db.vpis.Find(id);
            student student = vpi.student;

            VpisniListModel vpisniList = new VpisniListModel();  

            vpisniList.ime = student.ime;
            vpisniList.priimek = student.priimek;
            vpisniList.prenosniTelefon = student.prenosniTelefon;
            vpisniList.datumRojstva = student.datumRojstva;
            vpisniList.davcnaStevilka = student.davcnaStevilka ?? 00000000;
            vpisniList.emso = student.emso;
            vpisniList.email = student.email;
            vpisniList.krajRojstva = student.krajRojstva;
            vpisniList.obcinaRojstva = student.obcinaRojstva;
            vpisniList.drzavaRojstva = student.drzavaRojstva;
            vpisniList.drzavljanstvo = student.drzavljanstvo;

            vpisniList.vrocanje = student.vrocanje ?? default(bool);
            vpisniList.naslov = student.naslov;
            vpisniList.obcina = student.obcina;
            vpisniList.postnaStevilka = student.postnaStevilka;
            vpisniList.drzava = student.drzava;

            vpisniList.vrocanjeZacasni = student.vrocanjeZacasni ?? default(bool);
            vpisniList.naslovZacasni = student.naslovZacasni ?? default(string);
            vpisniList.obcinaZacasni = student.obcinaZacasni ?? default(int);
            vpisniList.postnaStevilkaZacasni = student.postnaStevilkaZacasni ?? default(int);
            vpisniList.drzavaZacasni = student.drzavaZacasni ?? default(int);

            vpisniList.studijskiProgram = vpi.studijskiProgram;
            vpisniList.smer = vpi.smer ?? default(int);
            vpisniList.krajIzvajanja = vpi.krajIzvajanja;
            vpisniList.izbirnaSkupina = vpi.izbirnaSkupina;
            vpisniList.studijskiProgram2 = vpi.studijskiProgram2 ?? default(int);
            vpisniList.smer2 = vpi.smer2 ?? default(int);
            vpisniList.krajIzvajanja2 = vpi.krajIzvajanja2 ?? default(int);
            vpisniList.izbirnaSkupina2 = vpi.izbirnaSkupina2 ?? default(int);
            vpisniList.vrstaStudija = vpi.vrstaStudija;
            vpisniList.vrstaVpisa = vpi.vrstaVpisa;
            vpisniList.letnikStudija = vpi.letnikStudija;
            vpisniList.nacinStudija = vpi.nacinStudija;
            vpisniList.oblikaStudija = vpi.oblikaStudija;
            vpisniList.studijskoLetoPrvegaVpisa = vpi.studijskoLetoPrvegaVpisa;
            vpisniList.soglasje1 = vpi.soglasje1 ?? default(bool);
            vpisniList.soglasje2 = vpi.soglasje2 ?? default(bool);
            vpisniList.dr_dan = vpi.student.datumRojstva.Day;
            vpisniList.dr_mesec = vpi.student.datumRojstva.Month;
            vpisniList.dr_leto = vpi.student.datumRojstva.Year;

            return vpisniList;
        }
    }
}