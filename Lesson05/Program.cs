using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lesson05.DAL;
using Lesson05.Extensions;
using Lesson05.Models;

namespace Lesson05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            ShowOptionsAsync().Wait();

            Main(args);

            Console.WriteLine("1. Manage Incomes     2. Manage Expenses     3. Manage Categories");
        }

        static async Task ShowOptionsAsync()
        {
            Console.WriteLine("1. See all categories     2. Find category by id     3. Add Category");
            Console.WriteLine("4. Update category        5.Delete Category");

            int input = GetOptionInput();

            Console.Clear();

            switch (input)
            {
                case 1:
                    await GetAllCategoriesAsync();
                    break;
                case 2:
                    await GetCategoryByIdAsync();
                    break;
                case 3:
                    await CreateCategoryModuleAsync();
                    break;
                default:
                    return;
            }
        }

        public static async Task GetAllCategoriesAsync()
        {
            List<Category> categories = await CategoryService.GetAlLCategoriesAsync();

            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }

            Console.Write("Enter any key to continue");
            Console.ReadKey();
        }

        private static async Task CreateCategoryModuleAsync()
        {
            Console.WriteLine("Please, enter category values below.");
            Console.WriteLine();

            string categoryName = null;
            do
            {
                Console.Write("Enter new category name: ");
                categoryName = Console.ReadLine();
            }
            while (categoryName == null);

            await CategoryService.CreateCategory(new Models.Category(categoryName));

            Console.Write("Enter any key to continue");
            Console.ReadKey();
        }

        private static async Task GetCategoryByIdAsync()
        {
            Console.Write("Enter id: ");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.Write("Please, enter correct value.");
                Console.Write("Enter id: ");
            }

            Category category = await CategoryService.GetCategoryById(input);

            if (category is null)
            {
                ConsoleHelper.WriteLineError($"Category with id: {input} does not exist.");
            }
            else
            {
                Console.WriteLine(category);
            }

            Console.Write("Enter any key to continue");
            Console.ReadKey();
        }

        private static int GetOptionInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                ClearCurrentConsoleLine();
                Console.WriteLine("Please, try again.");
            }

            return input;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
