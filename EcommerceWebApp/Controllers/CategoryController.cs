

using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using EcommerceWebApp.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcommerceWebApp.Controllers
{


    public class CategoryController : Controller
    {
        //Inyección de dependencias: se recibe el contexto de base de datos

        //declaramos una variable privada dentro del controlador  llamada _bd
        //rendoy significa que solo se puede asignar una vez 
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db) //este es nuestro contructor del controlador 
        {
            //asignamos db a nuestro parametros _db para poderlo usar en todos los metodos 
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            //TempData.Remove("success");
            //TempData.Remove("error");
            //esta es la respuesta del controlador puede ser una vista, un redireccionamiento, un JSON, etc.
            //index es la pagina principal de este controlador 
            //aqui pasamos los datos del metodo antes de que lleguen a la vista 
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);//devuelve la vista correspondiente 
        }

        public IActionResult Create()
        {
            // Pasamos las listas para validación dinámica incluso antes de enviar el formulario
            //ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
            //ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            // Validación básica
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "El nombre de la categoría no debe ser el mismo que el Orden de visualización.");
            }

            //// Validación de rango DisplayOrder
            //if (category.DisplayOrder > 50)
            //{
            //    ModelState.AddModelError("DisplayOrder", "El Orden de visualización no puede ser mayor a 50.");
            //}

            //// Validamos duplicados solo si DisplayOrder es válido
            //// Solo validamos Name si no está vacío
            //if (!string.IsNullOrWhiteSpace(category.Name))
            //{
            //    bool nameExist = _db.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            //    if (nameExist)
            //    {
            //        ModelState.AddModelError("Name", $"Ya existe una categoría con el nombre '{category.Name}'.");
            //    }
            //}

            //// Solo validamos DisplayOrder si es válido (<=50)
            //if (category.DisplayOrder > 0 && category.DisplayOrder <= 50)
            //{
            //    bool displayExists = _db.Categories.Any(c => c.DisplayOrder == category.DisplayOrder);
            //    if (displayExists)
            //    {
            //        ModelState.AddModelError("DisplayOrder", $"Ya existe una categoría con el Orden de visualización '{category.DisplayOrder}'.");
            //    }
            //}


            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["success"] = "Categoria agregada exitosamente";
                //// Guardar con la primera letra en mayúscula
                //if (!string.IsNullOrWhiteSpace(category.Name))
                //{
                //    category.Name = char.ToUpper(category.Name[0]) + category.Name.Substring(1).ToLower();
                //}

                //_db.Categories.Add(category);
                //_db.SaveChanges();

                //TempData["success"] = $"La categoría '{category.Name}' se ha guardado correctamente.";

                //// Actualizamos ViewBag para la validación dinámica
                //ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
                //ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();

                return RedirectToAction("Index");
               // return View(category);

            }

            return View();

            //// Si hay errores, también actualizamos ViewBag
            //ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
            //ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();

            //return View(category);
        }

        // editar 
        public IActionResult Edit(int? id)//devuelve una vista para editar categoria 
            //recibe de parametro un Id que ala vez puede ser null , int? ya que el usuario podria no enviar ningun valor en la URL
        {
            

            if (id == null || id == 0)
            {
                //si no llega un Id o es 0 devuelve un 404 NotFound
                //esto evita errores si alguien accede en /Category/Edit/ con un id invalido 
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id == id);
            //busca categoria por su clave primaria 
            //Category? categoryFromBd1 = _db.Categories.FirstOrDefault(x => x.Id == id);//busca categoria que cumpla con la condicion o devuelve null
            //Category? categoryFromBd2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();//filtra categoria por id == id y toma la primera  o null


            if (categoryFromDb == null)// si no se necuentra ninguna categoria con ese id regresa 404 
            {
                return NotFound();
            }

            return View(categoryFromDb);// si encontro categoria envia los datos  ala vista edit donde el usuario podra ver los campos y modificarlos
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
        //    // 🔹 Paso 1: Revisamos que la categoría enviada desde el formulario no sea null
        //    if (category == null)
        //        return NotFound(); // Si no existe, devolvemos 404

        //    // 🔹 Paso 2: Buscamos la categoría original en la base de datos usando su Id
        //    var categoryFromDb = _db.Categories.Find(category.Id);
        //    if (categoryFromDb == null)
        //        return NotFound(); // Si no existe en la BD, devolvemos 404

        //    // 🔹 Paso 3: Validaciones simples

        //    // Que el nombre no sea igual al número de DisplayOrder
        //    if (category.Name == category.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("Name", "El nombre no debe ser igual al número de orden.");
        //    }

        //    // Que no exista otra categoría con el mismo nombre (ignorando la categoría que estamos editando)
        //    if (!string.IsNullOrWhiteSpace(category.Name))
        //    {
        //        bool nameExist = _db.Categories.Any(c => c.Id != category.Id && c.Name.ToLower() == category.Name.ToLower());
        //        if (nameExist)
        //        {
        //            ModelState.AddModelError("Name", $"Ya existe una categoría con el nombre '{category.Name}'.");
        //        }
        //    }

        //    // 🔹 Paso 4: Si todo está bien (sin errores), empezamos a actualizar
        //    if (ModelState.IsValid)
        //    {
        //        // ----------- Actualizar el nombre si cambió -----------
        //        if (!string.IsNullOrWhiteSpace(category.Name) && categoryFromDb.Name != category.Name)
        //        {
        //            // Ponemos la primera letra en mayúscula y las demás en minúscula
        //            categoryFromDb.Name = char.ToUpper(category.Name[0]) + category.Name.Substring(1).ToLower();
        //        }

        //        // ----------- Reordenamiento del DisplayOrder -----------
        //        if (category.DisplayOrder != categoryFromDb.DisplayOrder)
        //        {
        //            // 🔹 Paso 4.1: Traemos todas las categorías ordenadas por DisplayOrder
        //            var allCategories = _db.Categories
        //                                   .OrderBy(c => c.DisplayOrder)
        //                                   .ToList();

        //            // 🔹 Paso 4.2: Quitamos la categoría que estamos editando de la lista
        //            allCategories.Remove(categoryFromDb);

        //            // 🔹 Paso 4.3: Insertamos la categoría en la nueva posición
        //            // Por ejemplo, si el usuario pone DisplayOrder = 3, la ponemos en índice 2 (porque los índices empiezan en 0)
        //            int newIndex = category.DisplayOrder - 1;
        //            if (newIndex < 0) newIndex = 0; // por si el usuario pone un número muy chico
        //            if (newIndex > allCategories.Count) newIndex = allCategories.Count; // por si pone un número muy grande
        //            allCategories.Insert(newIndex, categoryFromDb);

        //            // 🔹 Paso 4.4: Recalculamos todos los DisplayOrder para que queden consecutivos 1, 2, 3...
        //            for (int i = 0; i < allCategories.Count; i++)
        //            {
        //                allCategories[i].DisplayOrder = i + 1;
        //            }
        //        }

        //        // 🔹 Paso 5: Guardamos todos los cambios en la base de datos
        //        _db.SaveChanges();

        //        // 🔹 Paso 6: Mensaje de éxito para mostrar en la vista
        //        TempData["success"] = $"La categoría '{categoryFromDb.Name}' se ha editado correctamente.";

        //        // 🔹 Paso 7: Actualizamos ViewBag para validaciones dinámicas en la vista
        //        ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
        //        ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();

        //        // 🔹 Paso 8: Devolvemos la vista con los datos actualizados
        //        return View(categoryFromDb);
        //    }

        //    // 🔹 Si hay errores de validación, también mantenemos ViewBag actualizado
        //    ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
        //    ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();

        //    return View(categoryFromDb);

            if(ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                TempData["success"] = "Categoria actualizada exitosamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //eliminar------------

        public IActionResult Delete(int? id)//devuelve una vista para editar categoria 
                                          //recibe de parametro un Id que ala vez puede ser null , int? ya que el usuario podria no enviar ningun valor en la URL
        {


            if (id == null || id == 0)
            {
                //si no llega un Id o es 0 devuelve un 404 NotFound
                //esto evita errores si alguien accede en /Category/Edit/ con un id invalido 
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id== id);
            //busca categoria por su clave primaria 
            //Category? categoryFromBd1 = _db.Categories.FirstOrDefault(x => x.Id == id);//busca categoria que cumpla con la condicion o devuelve null
            //Category? categoryFromBd2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();//filtra categoria por id == id y toma la primera  o null

            //TempData["success"] = $"La categoría '{categoryFromDb.Name}' se ha eliminado correctamente.";

            //// 🔹 Paso 7: Actualizamos ViewBag para validaciones dinámicas en la vista
            //ViewBag.ExistingNames = _db.Categories.Select(c => c.Name.ToLower()).ToList();
            //ViewBag.ExistingDisplays = _db.Categories.Select(c => c.DisplayOrder).ToList();

            if (categoryFromDb == null)// si no se necuentra ninguna categoria con ese id regresa 404 
            {
                return NotFound();
            }

            return View(categoryFromDb);// si encontro categoria envia los datos  ala vista edit donde el usuario podra ver los campos y modificarlos
        }
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _categoryRepo.Get(u => u.Id== id);
            if (category == null)
            {
                // Si no existe, lo mandamos al Index con mensaje de error opcional
                //TempData["error"] = "La categoría que intentaste eliminar no existe.";
                //return RedirectToAction("Index");
            }

           // _db.Categories.Remove(category);
           //_db.SaveChanges();
           _categoryRepo.Remove(category);
            _categoryRepo.Save();

            TempData["success"] = "La categoría se ha eliminado correctamente";
            //ViewBag.SuccessMessage = "Categoría eliminada correctamente. Redirigiendo a la lista...";

            return RedirectToAction("Index");
        }


    }
}

