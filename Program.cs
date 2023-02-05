// See https://aka.ms/new-console-template for more information

linqQueries queries = new linqQueries();

/*Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
foreach (var item in queries.Get())
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
}*/


// Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.LibrosConMasde250PagConPalabrasInAction())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }
// Console.WriteLine(queries.allBooksWihtStatus());
// Console.WriteLine(queries.anyBooksPublic2005());

// Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.bookOfPython())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }

// Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.OrderByDescendinPage())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }

// Console.WriteLine("\n{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.OrderByTitle())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }

// Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.FirstThreeBooks())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }

// Console.WriteLine("\n{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
// foreach (var item in queries.ThirdAndFourthBooks())
// {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
// }

// Console.WriteLine(queries.CountBooks());
// Console.WriteLine(queries.DatePublicMin());
// Console.WriteLine(queries.PageNamberMax());
// var libroNumeroPaginaMenor = queries.PageNamberMinBy();
// Console.WriteLine($"{libroNumeroPaginaMenor.Title} - {libroNumeroPaginaMenor.PublishedDate.ToShortDateString()}");

// var libroFechaPubReciente = queries.DAtePublicMaxBy();
// Console.WriteLine($"{libroFechaPubReciente.Title} - {libroFechaPubReciente.PublishedDate.ToShortDateString()}");

//me estpos quedando sin nombres xd
// Console.WriteLine(queries.SumaDeTodasLasPaginasLibrosEntre0y500());
// Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());
// Console.WriteLine(queries.PromedioCaracteresTitulo());

// ImprimirGrupo(queries.LibrosDespuesdel2000AgrupadosporAno());

// var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
// ImprimirDiccionario(diccionarioLookup, 'A');


// void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
// {
//     foreach (var grupo in ListadeLibros)
//     {
//         Console.WriteLine("");
//         Console.WriteLine($"Grupo: {grupo.Key}");
//         Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
//         foreach (var item in grupo)
//         {
//             Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
//         }
//     }
// }

//     void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
//     {
//     Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
//     foreach (var item in ListadeLibros[letra])
//     {
//         Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
//     }


// }


Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
foreach (var item in queries.LibrosConMasde250PagConPalabrasInAction())
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
}