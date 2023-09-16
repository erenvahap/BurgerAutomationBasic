using BurgerAutomation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAutomation.Models
{
    public class Order : BaseEntity
    {

        public Order()
        {
            Ingredients = new List<ExtraIngredient>();
        }

        public BurgerMenu SelectedMenu { get; set; }
        public short Number { get; set; }
        public Sizes Size{ get; set; }
        public List<ExtraIngredient> Ingredients { get; set; }


        public void CalculateBill()
        {
            Price = SelectedMenu.Price;

            switch (Size)
            {
                case Sizes.Small:
                    Price -= 1;
                    break;
               
                case Sizes.Big:
                    Price += 2;
                    break;
            }

            foreach (ExtraIngredient item in Ingredients)
            {
                Price += item.Price;
            }

            Price *= Number;
        }

        public override string ToString()
        {
           if(Ingredients.Count < 1)
           {

                return $"{Name} is going to have : {SelectedMenu.Name} Menu, x {Number}, {Size} Sized, Total will be : {Price:C2}";
           }

            string Ingredient = null;

            foreach (ExtraIngredient item in Ingredients)
            {

                Ingredient += $"{item.Name},";
            }

            Ingredient = Ingredient.TrimEnd(','); 

            return $"{Name} is having a, {SelectedMenu.Name} Menu, x {Number}, {Size} Sized, Ingredients : {Ingredient}), In total => {Price:C2} ";

        }
    }
}
