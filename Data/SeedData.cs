using PXLApp.Models;

namespace PXLApp3.Data
{
    public class SeedData
    {

        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.gebruikers.Any())
                {
                context.gebruikers.AddRange(
                    new Gebruiker { Naam = "Swennen", Voornaam = "Tom", Email = "tswennen@gmail.com" },
                    new Gebruiker { Naam = "Palmaers", Voornaam = "Kristof", Email = "Kristof.Palmaers@pxl.be" });

                context.SaveChanges();

                //try { context.SaveChanges(); }
                //catch (Exception ex)
                //{
                //    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                //}
            }

            if(!context.students.Any())
            {
                context.students.Add(new Student { GebruikerId = 1 });
                context.SaveChanges();

                //try { context.SaveChanges(); }
                //catch (Exception ex)
                //{
                //    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                //}

            }

            if (!context.lectors.Any())
            {
                context.lectors.Add(new Lector {GebruikerId = 2 });
                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

            if (!context.academieJaren.Any())
            {
                context.academieJaren.Add(new AcademieJaar { StartDatum = new DateTime(2023,09,20)});
                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

            if (!context.handboeken.Any())
            {
                context.handboeken.Add(new Handboek { Titel="C# Web 1", KostPrijs=120, Uitgiftedatum = new DateTime(2021, 01,01), Afbeelding="imagelink" });
                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

            if (!context.vakken.Any())
            {
                context.vakken.Add(new Vak { VakNaam="C# Web 1", Studiepunten=36, HandboekId=1});
                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

            if (!context.vakLectoren.Any())
            {
                context.vakLectoren.Add(new VakLector { VakId = 1, LectorId = 1 });
                //context.SaveChanges();

                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

            if (!context.inschrijvingen.Any())
            {
                context.inschrijvingen.Add(new Inschrijving { AcademieJaarId=1, StudentId=1, VakLectorId=1});
                //context.SaveChanges();

                try { context.SaveChanges(); }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                }
            }

        }

    }
}
