using System;
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

    public IEnumerable<Book> GetBookBefore2000()
    {
        //return listCollection.Where(x => x.PublishedDate.Year > 2000);

        return from l in listCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in listCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool allBooksWihtStatus()
    {
        return listCollection.All(p => p.Status != string.Empty);
    }

    public bool anyBooksPublic2005()
    {
        return listCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> bookOfPython()
    {
        return listCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> OrderByTitle()
    {
        return listCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> OrderByDescendinPage()
    {
        return listCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

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

    public IEnumerable<Book> FirstThreeBooksOfColletion()
    {
        return listCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }

    public long CountBooks()
    {
        return listCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime DatePublicMin()
    {
        return listCollection.Min(p => p.PublishedDate);
    }

    public int PageNamberMax()
    {
        return listCollection.Max(p => p.PageCount);
    }

    public Book PageNamberMinBy()
    {
        return listCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book DAtePublicMaxBy()
    {
        return listCollection.MaxBy(p => p.PublishedDate);
    }

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

    public double PromedioCaracteresTitulo()
    {
        return listCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
    {
        return listCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return listCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDepuesdel2005 = listCollection.Where(p => p.PublishedDate.Year > 2005);

        var LibrosConMasde500pag = listCollection.Where(p => p.PageCount > 500);

        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p => p.Title, x => x.Title, (p, x) => p);
    }
}
