
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> relations =
            new Dictionary<string, List<string>>(
                StringComparer.OrdinalIgnoreCase)
            {
                { "C#", new List<string> { ".NET", "OOP", "Visual Studio" } },
                { "Database", new List<string> { "SQL", "Table", "Query" } },
                { "API", new List<string> { "HTTP", "JSON", "Endpoint" } }
            };

        Console.WriteLine("Proqramlasdirma terminlerinin elaqeleri:\n");

        foreach (var item in relations)
        {
            Console.WriteLine(
                $"{item.Key} elaqelidir ? " +
                string.Join(", ", item.Value)
            );
        }

        Console.Write("\nAxtarmaq istediyiniz termini daxil edin: ");

        string term = (Console.ReadLine() ?? "").Trim();

        GetRelated(term, relations);
    }

    static void GetRelated(
        string term,
        Dictionary<string, List<string>> relations)
    {
        if (relations.TryGetValue(term, out List<string> relatedTerms))
        {
            Console.WriteLine(
                $"\n'{term}' termini ile elaqeli sozler: " +
                string.Join(", ", relatedTerms)
            );
        }
        else
        {
            // Əlaqəli sözlərin özündə də axtarış edirik.
            bool found = false;

            foreach (var item in relations)
            {
                foreach (string relatedTerm in item.Value)
                {
                    if (string.Equals(
                        relatedTerm,
                        term,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            $"\n'{term}' termini '{item.Key}' ile elaqelidir."
                        );

                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine(
                    $"\n'{term}' termini ucun elaqe tapilmadi."
                );
            }
        }
    }
}
