using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class RecipeFactory
    {
        private static readonly List<Recipies> recipies = new List<Recipies>();

        static RecipeFactory()
        {
            Recipies granolaBarRec = new Recipies(1, "Granola Bar");

            granolaBarRec.AddIngridient(9007, 1);
            granolaBarRec.AddIngridient(9008, 1);
            granolaBarRec.AddIngridient(9009, 1);
            granolaBarRec.AddOutputItem(2001, 1);

            recipies.Add(granolaBarRec);
        }

        public static Recipies getRecipeByID(int id) => recipies.FirstOrDefault(x => x.ID == id);
    }
}
