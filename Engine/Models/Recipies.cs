using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// С помощью этого класса мы создаем новые рецепты для крафта
    /// </summary>
    public class Recipies
    {
        #region public properties

        /// <summary>
        /// Поле - идентификатор рецепта
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Поле имя)
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список ингридиентов на крафт
        /// </summary>
        public List<ItemQuantity> Ingridiets { get; } = new List<ItemQuantity>();

        /// <summary>
        /// Результат крафта
        /// </summary>
        public List<ItemQuantity> OutputItems { get; } = new List<ItemQuantity>();

        #endregion

        /// <summary>
        /// Дефолтный конструктор, в котором задаем рецепту имя и айдишник)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Recipies(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void AddIngridient(int itemID , int quantity)
        {

            // С помощью линкю идем по листу ингридиентов, если мы не нашли похожий - добавляем
            if (!Ingridiets.Any(x => x.ItemID == itemID))
                Ingridiets.Add(new ItemQuantity(itemID, quantity));
        }

        public void AddOutputItem(int itemID, int quantity)
        {
            if (!OutputItems.Any(x => x.ItemID == itemID))
                OutputItems.Add(new ItemQuantity(itemID, quantity));
        }
    }
}
