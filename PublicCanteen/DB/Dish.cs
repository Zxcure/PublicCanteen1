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
    
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            this.DishOrder = new HashSet<DishOrder>();
        }
    
        public int IdDish { get; set; }
        public string NameDish { get; set; }
        public string DiscrDish { get; set; }
        public decimal PriceDish { get; set; }
        public string PhotoDish { get; set; }
        public Nullable<int> WeightDish { get; set; }
        public int IdCategoryDish { get; set; }
    
        public virtual CategoryDish CategoryDish { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishOrder> DishOrder { get; set; }
    }
}
