using schoolManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace schoolManagment.Controllers
{
    [Authorize]
    public class EtudiantController : Controller
    {
        private ContextDb _context;
        public EtudiantController()
        {
            _context = new ContextDb();
        }
        // GET: Etudiant
        public ActionResult Index()
        {
            EtudiantViewModel EtudiantList = new EtudiantViewModel
            {
                Etudiants = _context.Etudiants.ToList(),
            };
            return View(EtudiantList);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PopulateEtudiantViewModel populateEtudiantViewModel)
        {
            Etudiant etudiant = new Etudiant
            {
                CNE = populateEtudiantViewModel.CNE,
                Name = populateEtudiantViewModel.Name,
                Nickname = populateEtudiantViewModel.Nickname,
                DateNaissance = populateEtudiantViewModel.DateNaissance,
                Filiere = populateEtudiantViewModel.Filiere,
            };
            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EtudiantViewModel etudiantViewModel,string CNE)
        {
            var etudiant = _context.Etudiants.SingleOrDefault(e => e.CNE == CNE);
            if (etudiant == null)
            {
                ModelState.AddModelError("CNE","error");
                return View("Index");
            }
            _context.Etudiants.Remove(etudiant);
            _context.SaveChanges();
            return RedirectToAction("Index","Etudiant",etudiantViewModel);
        }
        public ActionResult Update(PopulateEtudiantViewModel etudiantViewModel,string CNE)
        {
            var etudiant = _context.Etudiants.SingleOrDefault(e => e.CNE == CNE);
            etudiantViewModel.Name = etudiant.Name;
            etudiantViewModel.Nickname = etudiant.Nickname;
            etudiantViewModel.DateNaissance = etudiant.DateNaissance;
            etudiantViewModel.Filiere = etudiant.Filiere;
            return View(etudiantViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PopulateEtudiantViewModel etudiantViewModel)
        {
            var etudiant = _context.Etudiants.Find(etudiantViewModel.CNE);
            if(etudiant == null)
            {
                ModelState.AddModelError("CNE", "something goes wrong");
                return View("Update",etudiantViewModel);
            }
            etudiant.Name = etudiantViewModel.Name;
            etudiant.Nickname = etudiantViewModel.Nickname;
            etudiant.DateNaissance= etudiantViewModel.DateNaissance;
            etudiant.Filiere= etudiantViewModel.Filiere;
            etudiant.CNE = etudiantViewModel.CNE;

            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
            
            return View("Index",etudiantViewModel);
        }





    }
}