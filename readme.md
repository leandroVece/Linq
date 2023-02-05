#LINQ

>Requisitos: conocimiento en C#, conocimiento en .net, tener instalado el SDK de .net vcCode

LINQ es un conjunto de tecnologías en .NET que viene del término (Language Integrated Query) que sirve para consultar datos desde diferentes fuentes de datos.

Es una herramienta que nos permite tener un código más limpio. Es una herramienta muy buena para el desarrollo Backend. no voy a dar muchas explicaciones sobre la teoría y me voy a concentrar un poco más en la practica.

comencemos con crear un proyecto nuevo de consola.

    dotnet new console

Como solo me voy a concentrar en la parte lógica del programa recomiendo descargar el archivo que esta en este repositorio llamado books.json.

Despues iremos a nuestro archivo csproj y agregaremos la siguiente linea de codigo

    <ItemGroup>
        <Content Include="books.json" />
    </ItemGroup>

Como ya sabemos necesitamos una clase que nos permitira manipular nuestro json dentro de C#.

    class books
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Status { get; set; }
        public string[] Autor { get; set; }
        public string[] Categories { get; set; }
    }

y crearemos una clase mas para guardar nuestras queries.

    class linqQueries
    {

        private List<Book> listCollection = new List<Book>();
        public linqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.listCollection = System.Text.Json.JsonSerializer
                .Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public IEnumerable<Book> Get()
        {
            return listCollection;
        }

    }

Luego vamos a nuestro archivo program.cs y imprimimos nuestro archivo para ver si todo esta funcionando.

    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in queries.Get())
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

Ya que hemos comprobado que todo esta andando correctamente, comencemos a trabajar con Linq. La primera sentencia de la que vamos a hablar es de la sentencia Where.

Esta sentencia al igual que en la BD sirve como filtro. Veamoslo en practica, en nuestra clase linqQueries.cs agreguemos un nuevo metodo.

     public IEnumerable<Book> GetBookBefore2000()
    {
        return listCollection.Where(x => x.PublishedDate.Year > 2000);
    }

Obtendremos el mismo resultado so lo modificamos de la siguiente manera.

    public IEnumerable<Book> GetBookBefore2000()
    {
        return from l in listCollection where l.PublishedDate.Year > 2000 select l;
    }

de la misma manera que en sql podemos poner mas de una condicion en nuestra sentencia where.

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        //return from l in listCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

La siguiente sentencias que vamos a probar sera la de Any y All.

 public bool allBooksWihtStatus()
    {
        return listCollection.All(p => p.Status != string.Empty);
    }

    public bool anyBooksPublic2005()
    {
        return listCollection.Any(p => p.PublishedDate.Year == 2005);
    }

Con estos dos metodos nuevos verificamos si todos los libros tienen status y verificamos si hay un libro que fue puclicado en el 2005.

En el caso de coincidir nos devolveran un true de lo contrario un false.

El operador Contains nos permite verificar si existe un elemento en especifico en nuestra coleccion.

    public IEnumerable<Book> bookOfPython()
    {
        return listCollection.Where(p => p.Categories.Contains("Python"));
    }

Otro operador nos va a permitir ordenas nuestras colecciones. estas son OrderBy y OrderByDescending que como su nombre nos dice, nos permiten ordenar de acuerdo a un criterio de forma ascendente o descendente respectivamente.

    public IEnumerable<Book> OrderByTitle()
    {
        return listCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> OrderByDescendinPage()
    {
        return listCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

Los operadores Take y el operador Skip, son utiles al momento de seleccionar una cantidad especifica de elementos de una coleccion.
- Take devuelve la cantidad especificada.
- Skip ignora o omite una cantidad especificada.

        public IEnumerable<Book> FirstThreeBooks()
        {
            return listCollection
            .Where(p => p.Categories.Contains("Java"))
            .OrderBy(p => p.PublishedDate)
            .TakeLast(3);
        }

        public IEnumerable<Book> ThirdAndFourthBooks()
        {
            return listCollection
            .Where(p => p.PageCount > 400)
            .Take(4)
            .Skip(2);
        }

La logica es simple en la primera llamo los primeros 3 libros de java y en la segunda llamo los primeros 4 y omito los primeros 2.

Hasta ahora hemos estado trayendo nuestra informacion de nuestro json y por medio de una logica simple llamando aquellos datos que queremos mostrar, pero con el operador select podemos llamar los datos que queremos mostrar.

    public IEnumerable<Book> FirstThreeBooksOfColletion()
    {
        return listCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }

>Si ves con atencion los datos de fecha se llena por defecto.

Es el turno de los operadores LongCount y count. los dos hacen practicamente lo mismo solo que Count soporta 32 bit y el otro 64 bit.
como su nombre sugiere esté cuenta la cantidad de registros que tenemos en nuestra coleccion.

     public long CountBooks()
    {
        return listCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

Otros operadores relacionados son los operadores Min y Max, que nos permitiran encontrar valores maximos y minimos.

     public DateTime DatePublicMin()
    {
        return listCollection.Min(p => p.PublishedDate);
    }

    public int PageNamberMax()
    {
        return listCollection.Max(p => p.PageCount);
    }

Estos son bueno para trabajar con trabajar con datos tipos primitivos, pero son malos para los completos. Para ello C# ofrecio la solucion con dos nuevos operadores llamado Maxby y MinBY

    public Book PageNamberMinBy()
    {
        return listCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book DAtePublicMaxBy()
    {
        return listCollection.MaxBy(p => p.PublishedDate);
    }

Tambien existen operadores que realizan calculos, como los operadores Sum y Aggregate

     public int SumaDeTodasLasPaginasLibrosEntre0y500()
    {
        return listCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return listCollection
                .Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("", (TitleBook, next) =>
                {
                    if (TitleBook != string.Empty)
                        TitleBook += " - " + next.Title;
                    else
                        TitleBook += next.Title;

                    return TitleBook;
                });
    }

El operador Average nos permite sacar un promedio de alguna propiedad de nuestra coleccion.

public double PromedioCaracteresTitulo()
    {
        return listCollection.Average(p => p.Title.Length);
    }

Por ultimo vamos a trabajar con los operadores de agrupamientos que son la clausula GroupBy, Lookup y Join.
La primera nos premite agrupar los elementos por una propiedad especifica.

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
    {
        return listCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

>Nota: presten atencion como es que devolvemos una coleccion que tiene el dato que manejamos en nuestra clausura y el objeto con lo que estamos trabajando.

La forma de llamarlo es la siguiente.
 
    void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
    {
        foreach (var grupo in ListadeLibros)
        {
            Console.WriteLine("");
            Console.WriteLine($"Grupo: {grupo.Key}");
            Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var item in grupo)
            {
                Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
            }
        }
    }
Los Lookup nos premite agrupar en forma de diccionario.

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return listCollection.ToLookup(p => p.Title[0], p => p);
    }

    void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in ListadeLibros[letra])
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }

La ultima clausura que veremos es la clausula Join, que nos permite intecertar dos elementos y devolverlo.

    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDepuesdel2005 = listCollection.Where(p => p.PublishedDate.Year > 2005);

        var LibrosConMasde500pag = listCollection.Where(p => p.PageCount > 500);

        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p => p.Title, x => x.Title, (p, x) => p);
    }
