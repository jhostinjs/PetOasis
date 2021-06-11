using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PetOasis.Models;

namespace PetOasis.Controllers
{
    public class PetOasisController : Controller
    {
        string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        IEnumerable<Animal> animales()
        {
            List<Animal> temporal = new List<Animal>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_animal", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Animal reg = new Animal()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        tipo = dr.GetInt32(2),
                        rescate = dr.GetDateTime(3),
                        sexo = dr.GetString(4),
                        tamaño = dr.GetString(5),
                        estado = dr.GetInt32(6),
                        nacimiento = dr.GetString(7),
                        disponibilidad = dr.GetInt32(8),
                        imgAni = dr.GetString(9)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Accesorio> accesorios()
        {
            List<Accesorio> temporal = new List<Accesorio>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_accesorios", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio reg = new Accesorio()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        cantidad = dr.GetInt32(3),
                        categoria = dr.GetInt32(4),
                        tipo = dr.GetInt32(5),
                        disponibilidad = dr.GetInt32(6),
                        imgAcc = dr.GetString(7)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Alimento> alimentos()
        {
            List<Alimento> temporal = new List<Alimento>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_alimento", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Alimento reg = new Alimento()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        cantidad = dr.GetInt32(3),
                        tipo = dr.GetInt32(4),
                        disponibilidad = dr.GetInt32(5),
                        imgAli = dr.GetString(6)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Categoria> categorias()
        {
            List<Categoria> temporal = new List<Categoria>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_categoria", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria reg = new Categoria()
                    {
                        codigo = dr.GetInt32(0),
                        descripcion = dr.GetString(1)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<TipoAnimal> tiposani()
        {
            List<TipoAnimal> temporal = new List<TipoAnimal>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_tipoAnimal", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoAnimal reg = new TipoAnimal()
                    {
                        codigo = dr.GetInt32(0),
                        tipo = dr.GetString(1)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Disponibilidad> dispo()
        {
            List<Disponibilidad> temporal = new List<Disponibilidad>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_disponibilidad", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Disponibilidad reg = new Disponibilidad()
                    {
                        codigo = dr.GetInt32(0),
                        descripcion = dr.GetString(1)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Estado> estados()
        {
            List<Estado> temporal = new List<Estado>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_estado", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Estado reg = new Estado()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        Animal Buscar(int id = 0)
        {
            Animal reg = animales().Where(c => c.codigo == id).FirstOrDefault();
            if (reg == null)
                reg = new Animal();

            return reg;
        }
        Alimento BuscarAli(int id = 0)
        {
            Alimento reg = alimentos().Where(c => c.codigo == id).FirstOrDefault();
            if (reg == null)
                reg = new Alimento();

            return reg;
        }
        Accesorio BuscarAcc(int id=0)
        {
            Accesorio reg = accesorios().Where(c => c.codigo == id).FirstOrDefault();
            if (reg == null)
                reg = new Accesorio();

            return reg;
        }

        Accesorio BusAccDet(int ? id = 0)
        {
            if (id == null)
                return new Accesorio();
            else
                return accesorios().Where(c => c.codigo == id).FirstOrDefault();
        }

        Alimento BusAliDet(int? id = 0)
        {
            if (id == null)
                return new Alimento();
            else
                return alimentos().Where(c => c.codigo == id).FirstOrDefault();
        }

        IEnumerable<Animal> filtrazo(string nombre, List<SqlParameter> pars=null)
        {
            List<Animal> temporal = new List<Animal>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(nombre, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (pars != null) cmd.Parameters.AddRange(pars.ToArray());
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Animal reg = new Animal()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        tipo = dr.GetInt32(2),
                        rescate = dr.GetDateTime(3),
                        sexo = dr.GetString(4),
                        tamaño = dr.GetString(5),
                        estado = dr.GetInt32(6),
                        nacimiento = dr.GetString(7),
                        disponibilidad = dr.GetInt32(8),
                        imgAni = dr.GetString(9)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }


        IEnumerable<Accesorio> filtrazoAcc(string nombre, List<SqlParameter> pars= null)
        {
            List<Accesorio> temporal = new List<Accesorio>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(nombre, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (pars != null) cmd.Parameters.AddRange(pars.ToArray());
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio reg = new Accesorio()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        cantidad = dr.GetInt32(3),
                        categoria = dr.GetInt32(4),
                        tipo = dr.GetInt32(5),
                        disponibilidad = dr.GetInt32(6),
                        imgAcc = dr.GetString(7)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Alimento> filtrazoAli(string nombre, SqlParameter tipo = null)
        {
            List<Alimento> temporal = new List<Alimento>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(nombre, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (tipo != null) cmd.Parameters.Add(tipo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Alimento reg = new Alimento()
                    {
                        codigo = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        cantidad = dr.GetInt32(3),
                        tipo = dr.GetInt32(4),
                        disponibilidad = dr.GetInt32(5),
                        imgAli = dr.GetString(6)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        /*int autogenAni()
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                //Ejecutar la funcion
                SqlCommand cmd = new SqlCommand("select dbo.autogenAni()", cn);
                cn.Open();
                //Ejecutar, se convierte a string porque ExecuteScalar es un object
                id = (int)cmd.ExecuteScalar();
                cn.Close();
            }
            return id;
        }*/

        IEnumerable<TarjetaAcc> tarjetasAcc(int id = 0)
        {
            List<TarjetaAcc> temporal = new List<TarjetaAcc>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_TarjetaAcc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codAcc", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TarjetaAcc reg = new TarjetaAcc()
                    {
                        fecha = dr.GetDateTime(0),
                        entrada = dr.GetString(1),
                        salida = dr.GetString(2),
                        detalle = dr.GetString(3)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<TarjetaAli> tarjetasAli(int id = 0)
        {
            List<TarjetaAli> temporal = new List<TarjetaAli>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_TarjetaAli", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codAli", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TarjetaAli reg = new TarjetaAli()
                    {
                        fecha = dr.GetDateTime(0),
                        entrada = dr.GetString(1),
                        salida = dr.GetString(2),
                        detalle = dr.GetString(3)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Operacion> operaciones()
        {
            List<Operacion> temporal = new List<Operacion>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select*from tb_Operacion", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Operacion reg = new Operacion()
                    {
                        codigo = dr.GetInt32(0),
                        descripcion = dr.GetString(1)
                    };
                    temporal.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }


        // GET: Mantenimientos
        public ActionResult ManAnimal(int id=0)
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            Animal reg = Buscar(id);

            ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo");
            ViewBag.estados = new SelectList(estados(), "codigo", "nombre", reg.estado);
            ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
            ViewBag.animales = animales();

            return View(reg);
        }

        [HttpPost]
        public ActionResult ManAnimal(Animal reg, HttpPostedFileBase archivo)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo");
                ViewBag.estados = new SelectList(estados(), "codigo", "nombre", reg.estado);
                ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
                ViewBag.animales = animales();

                return View(reg);
            }

            if (archivo == null)
            {
                ViewBag.mensaje = "No ha seleccionado ningun archivo de imagen";
                ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo");
                ViewBag.estados = new SelectList(estados(), "codigo", "nombre", reg.estado);
                ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
                ViewBag.animales = animales();
                return View(reg);
            }

            //int id = autogenAni(); 

            string ruta = "~/Imagenes/Animales/" + Path.GetFileName(archivo.FileName);
            SqlConnection cn = new SqlConnection(cadena);
            try
            {
                if (Buscar(reg.codigo) == null)
                {
                SqlCommand cmd = new SqlCommand("sp_agregarAni", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod", reg.codigo);
                cmd.Parameters.AddWithValue("@nom", reg.nombre);
                cmd.Parameters.AddWithValue("@tip", reg.tipo);
                cmd.Parameters.AddWithValue("@resc", reg.rescate);
                cmd.Parameters.AddWithValue("@sex", reg.sexo);
                cmd.Parameters.AddWithValue("@tam", reg.tamaño);
                cmd.Parameters.AddWithValue("@est", reg.estado);
                cmd.Parameters.AddWithValue("@nac", reg.nacimiento);
                cmd.Parameters.AddWithValue("@dis", reg.disponibilidad);
                cmd.Parameters.AddWithValue("@img", reg.imgAni);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i == 1){

                    archivo.SaveAs(Server.MapPath(ruta));
                    ViewBag.mensaje = "Archivo agregado";
                }
                }

                else
                {
                    SqlCommand cmd = new SqlCommand("sp_updateAni", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod", reg.codigo);
                    cmd.Parameters.AddWithValue("@nom", reg.nombre);
                    cmd.Parameters.AddWithValue("@tip", reg.tipo);
                    cmd.Parameters.AddWithValue("@resc", reg.rescate);
                    cmd.Parameters.AddWithValue("@sex", reg.sexo);
                    cmd.Parameters.AddWithValue("@tam", reg.tamaño);
                    cmd.Parameters.AddWithValue("@est", reg.estado);
                    cmd.Parameters.AddWithValue("@nac", reg.nacimiento);
                    cmd.Parameters.AddWithValue("@dis", reg.disponibilidad);
                    cmd.Parameters.AddWithValue("@img", ruta);
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        //Si inserto el registro, guardo el archivo en el servidor -- Utilice Server.MapPath()
                        archivo.SaveAs(Server.MapPath(ruta));
                        ViewBag.mensaje = "Archivo actualizado";
                    }
                }

            }
            catch (SqlException ex) { ViewBag.mensaje = ex.Message; }
            finally { cn.Close(); }


            ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo", reg.tipo);
            ViewBag.estados = new SelectList(estados(), "codigo", "nombre", reg.estado);
            ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
            ViewBag.animales = animales();

            return View(reg);
        }

        public ActionResult ManAccesorio(int id=0)
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            Accesorio reg = BuscarAcc(id);

            ViewBag.categoria = new SelectList(categorias(), "codigo", "descripcion", reg.categoria);
            ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
            ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo", reg.tipo);
            ViewBag.accesorio = accesorios();

            return View(reg);
        }

        public ActionResult KardexAcc(int id = 0)
        {
            ViewBag.usuario = Nombre();

            Accesorio reg = BusAccDet(id);
            if (reg == null)
                return RedirectToAction("ManAccesorio");

            ViewBag.operacion = new SelectList(operaciones(), "codigo", "descripcion", reg.codigo);
            ViewBag.tarjetas = tarjetasAcc(id);

            return View(reg);
        }

        [HttpPost]public ActionResult KardexAcc(int codigo, string detalle, int ope, int cantidad)
        {
            ViewBag.usuario = Nombre();

            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                if (ope == 1)
                {
                    SqlCommand cmd = new SqlCommand("update tb_accesorios set canAcc=canAcc+" + cantidad + "where codAcc=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAcc values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }
                if (ope == 2)
                {
                    SqlCommand cmd = new SqlCommand("update tb_accesorios set canAcc=canAcc-" + cantidad + "where codAcc=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAcc values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }
                if (ope == 3)
                {
                    SqlCommand cmd = new SqlCommand("update tb_accesorios set canAcc=canAcc-" + cantidad + "where codAcc=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAcc values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
                ViewBag.mensaje = "Accesorio Actualizado";
            }
            catch (SqlException ex)
            {
                ViewBag.mensaje = ex.Message;
                tr.Rollback();
            }
            finally { cn.Close(); }

            return RedirectToAction("KardexAcc");
        }

        public ActionResult ManAlimento(int id = 0)
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            Alimento reg = BuscarAli(id);

            ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo", reg.tipo);
            ViewBag.disponi = new SelectList(dispo(), "codigo", "descripcion", reg.disponibilidad);
            ViewBag.alimento = alimentos();

            return View(reg);
        }

        public ActionResult KardexAli(int id = 0)
        {
            ViewBag.usuario = Nombre();

            Alimento reg = BusAliDet(id);
            if (reg == null)
                return RedirectToAction("ManAlimento");

            ViewBag.operacion = new SelectList(operaciones(), "codigo", "descripcion", reg.codigo);
            ViewBag.tarjetas = tarjetasAli(id);

            return View(reg);
        }

        [HttpPost]public ActionResult KardexAli(int codigo, string detalle, int ope, int cantidad)
        {
            ViewBag.usuario = Nombre();

            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                if (ope == 1)
                {
                    SqlCommand cmd = new SqlCommand("update tb_alimento set canAli=canAli+" + cantidad + "where codAli=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAli values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }
                if (ope == 2)
                {
                    SqlCommand cmd = new SqlCommand("update tb_alimento set canAli=canAli-" + cantidad + "where codAli=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAli values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }
                if (ope == 3)
                {
                    SqlCommand cmd = new SqlCommand("update tb_alimento set canAli=canAli-" + cantidad + "where codAli=" + codigo, cn, tr);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert tb_KardexAli values(@cod,@fec,@ope,@can,@det)", cn, tr);
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    cmd.Parameters.AddWithValue("@fec", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ope", ope);
                    cmd.Parameters.AddWithValue("@can", cantidad);
                    cmd.Parameters.AddWithValue("@det", detalle);
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
                ViewBag.mensaje = "Alimento Actualizada";
            }
            catch (SqlException ex)
            {
                ViewBag.mensaje = ex.Message;
                tr.Rollback();
            }
            finally { cn.Close(); }

            return RedirectToAction("KardexAli");
        }

        public ActionResult Adoptar(int tipo=0, string sexo="")
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            List<SqlParameter> lista = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName="@tipo", Value=tipo},
                new SqlParameter(){ParameterName="@sexo", Value=sexo}
            };

            IEnumerable<Animal> temporal = filtrazo("sp_filtroAnimal", lista);

            /*ViewBag.tipoAni = new SelectList(tiposani(), "codigo", "tipo", reg.tipo);
            ViewBag.sexo = sexo;*/

            return View(temporal);
        }

        public ActionResult ComprarAccesorios(int tipo = 0, int categoria = 0)
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            List<SqlParameter> lista = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName="@tipo", Value=tipo},
                new SqlParameter(){ParameterName="@cat", Value=categoria}
            };

            IEnumerable<Accesorio> temporal = filtrazoAcc("sp_filtroAccesorio", lista);

            return View(temporal);
        }

        public ActionResult ComprarAlimentos(int tipo = 0)
        {
            ViewBag.usuario = Nombre();

            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            IEnumerable<Alimento> temporal = filtrazoAli("sp_filtroAlimento", new SqlParameter() { ParameterName = "@tipo", Value = tipo });

            return View(temporal);
        }

        public ActionResult Agregar(int? id = null)
        {
            ViewBag.usuario = Nombre();

            if (id == null)
                return RedirectToAction("ComprarAccesorios");
            //Si id tiene valor, enviamos el producto seleccionado
            return View(BusAccDet(id));
        }

        [HttpPost]public ActionResult Agregar(int cod, int cantidad, int cant)
        {
            ViewBag.usuario = Nombre();
            Accesorio reg = BusAccDet(cod);

            if (cant > cantidad)
            {
                ViewBag.mensaje = string.Format("El producto {0}, solo dispone de {1} unidades",reg.nombre, reg.cantidad);
                return View(reg);
            }

            Item it = new Item()
            {
                codigo = reg.codigo,
                nombre = reg.nombre,
                precio = reg.precio,
                cantidad = cant,
            };
            //agregar it al Session carrito, referenciar con temporal
            List<Item> temporal = (List<Item>)Session["carrito"];
            temporal.Add(it);
            ViewBag.mensaje = "Producto Agregado";
            return View(reg);
        }

        public ActionResult AgregarAli(int? id = null)
        {
            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            ViewBag.usuario = Nombre();

            if (id == null)
                return RedirectToAction("ComprarAlimentos");

            return View(BusAliDet(id));
        }

        [HttpPost] public ActionResult AgregarAli(int cod, int cantidad, int cant)
        {
            ViewBag.usuario = Nombre();

            Alimento reg = BusAliDet(cod);

            if (cant > cantidad)
            {
                ViewBag.mensaje = string.Format("El producto {0}, solo dispone de {1} unidades", reg.nombre, reg.cantidad);
                return View(reg);
            }

            Item it = new Item()
            {
                codigo = reg.codigo,
                nombre = reg.nombre,
                precio = reg.precio,
                cantidad = cant,
            };
            //agregar it al Session carrito, referenciar con temporal
            List<Item> temporal = (List<Item>)Session["carrito"];
            temporal.Add(it);
            ViewBag.mensaje = "Producto Agregado";
            return View(reg);
        }

        public ActionResult Carrito()
        {
            ViewBag.usuario = Nombre();

            //visualizar el contenido del Session["carrito"], productos seleccionado
            return View((List<Item>)Session["carrito"]);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.usuario = Nombre();

            List<Item> temporal = (List<Item>)Session["carrito"];
            //buscar
            Item reg = temporal.Find(i => i.codigo == id);
            temporal.Remove(reg);

            return RedirectToAction("Carrito");
        }

        Usuario Buscar(string login, string clave)
        {

            Usuario reg = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_logueo", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", login);
                cmd.Parameters.AddWithValue("@clave", clave);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) 
                {
                    reg = new Usuario()
                    {
                        codigo = dr.GetString(0),
                        contraseña = dr["pwdUsu"].ToString(),
                        nombre = dr["nomUsu"].ToString(),
                        apellido = dr["apeUsu"].ToString(),
                        telefono = dr["telUsu"].ToString(),
                        email = dr["emailUsu"].ToString()
                    };
                }
                dr.Close();
                cn.Close();
            }
            return reg;
        }

        string Nombre()
        {
            if (Session["login"] == null)
                return null;
            else
                return "Bienvenido "+(Session["login"] as Usuario).nombre +" "+ (Session["login"] as Usuario).apellido;
        }

        public ActionResult Inicio()
        {
            if (Session["carrito"] == null)
                Session["carrito"] = new List<Item>();

            ViewBag.usuario = Nombre();
            return View();
        }

        [HttpPost]public ActionResult Inicio(string login, string clave)
        {
            ViewBag.usuario = Nombre();

            Usuario reg = Buscar(login, clave);

            if (reg == null)
            {
                ViewBag.mensaje = "Login o clave incorrecta";
                return View();
            }
            else
            {
                Session["login"] = reg;
                return RedirectToAction("Adoptar");
            }
        }

        public ActionResult Cerrar()
        {
            Session["login"] = null;
            return RedirectToAction("Adoptar");
        }

        public ActionResult Comprar()
        {
            ViewBag.usuario = Nombre();

            if (Session["login"] == null)
            {
                return RedirectToAction("Inicio");
            }
            else
            {
                ViewBag.usuario = Nombre();
                //Envio a la Vista el contenido del Session carrito
                ViewBag.carrito = (Session["carrito"] as List<Item>);
                //Envio a la vista los datos del cliente, hace la compra
                return View(Session["login"] as Usuario);
            }
        }

        string autogenerar()
        {
            string npedido = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select dbo.autogenera()", cn);
                cn.Open();

                npedido = (string)cmd.ExecuteScalar();
                cn.Close();
            }
            return npedido;
        }

        public ActionResult Pedido()
        {
            string npedido = autogenerar(); //Almaceno el numero del pedido
            string codigo = (Session["login"] as Usuario).codigo; //Almaceno el idcliente
            string mensaje = "";

            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {

                SqlCommand cmd = new SqlCommand("insert tb_pedido_header(npedido,codUsu) values(@pedido,@codusu)", cn, tr);
                cmd.Parameters.AddWithValue("@pedido", npedido);
                cmd.Parameters.AddWithValue("@codusu", codigo);
                cmd.ExecuteNonQuery();

                //Insertar en tb_pedido_deta con Session carrito
                foreach (Item it in (Session["carrito"] as List<Item>))
                {
                    cmd = new SqlCommand("insert tb_pedido_deta values(@pedido,@idpro,@precio,@stock)", cn, tr);
                    cmd.Parameters.AddWithValue("@pedido", npedido);
                    cmd.Parameters.AddWithValue("@idpro", it.codigo);
                    cmd.Parameters.AddWithValue("@precio", it.precio);
                    cmd.Parameters.AddWithValue("@stock", it.cantidad);
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
                mensaje = string.Format("El pedido {0} ha sido registrado", npedido);
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
                tr.Rollback(); 
            }
            finally { }

            //Redireccionar a una vista final donde imprima el mensaje del proceso
            return RedirectToAction("Aviso", new { m = mensaje });
        }

        public ActionResult Aviso(string m)
        {
            ViewBag.mensaje = m;
            return View();
        }
    }
}