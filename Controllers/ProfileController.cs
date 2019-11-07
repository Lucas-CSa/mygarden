using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using mygarden.Models;
using Microsoft.AspNetCore.Mvc;

namespace mygarden.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult Indique()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult CreateProd([FromForm] ProdutorModel produtor) {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mygarden;Uid=root;Pwd=root;"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO produtor (ProdNom, ProdBairro, ProdEnd, ProdNum, ProdTel, ProdDesc) VALUES (@ProdNom, @ProdBairro, @ProdEnd, @ProdNum, @ProdTel, @ProdDesc)", conn))
                {
                    cmd.Parameters.AddWithValue("@ProdNom", produtor.ProdNom);
                    cmd.Parameters.AddWithValue("@ProdBairro", produtor.ProdBairro);
                    cmd.Parameters.AddWithValue("@ProdEnd", produtor.ProdEnd);
                    cmd.Parameters.AddWithValue("@ProdNum", produtor.ProdNum);
                    cmd.Parameters.AddWithValue("@ProdTel", produtor.ProdTel);
                    cmd.Parameters.AddWithValue("@ProdDesc", produtor.ProdDesc);

                    cmd.ExecuteNonQuery();
                }
            }

            ViewBag.Mensagem = "Sucesso!";

            return View("Index");
        }
    }
}