//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicCanteen.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DishOrder
    {
        public int IdDishOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdDish { get; set; }
        public int CountDish { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
