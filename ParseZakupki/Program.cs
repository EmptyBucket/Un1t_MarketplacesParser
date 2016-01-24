using Ninject;
using ParseZakupki.Entity;

namespace ParseZakupki
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "TextFile1.txt"));

            var kernel = new StandardKernel(new Module());
            var zakupkiParser = kernel.Get<ZakupkiUploader>();
            var result = zakupkiParser.Upload();
            using (var dbContext = new PurchaseInformationContext())
            {
                dbContext.Purchase.AddRange(result);
                dbContext.SaveChanges();
            }
        }
    }
}
