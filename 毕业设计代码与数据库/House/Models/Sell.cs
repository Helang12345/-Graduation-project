//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sell()
        {
            this.SCollection = new HashSet<SCollection>();
            this.Selling = new HashSet<Selling>();
            this.SImg = new HashSet<SImg>();
            this.Transactions = new HashSet<Transactions>();
        }
    
        public int SellID { get; set; }
        public string SellAddress { get; set; }
        public string SellVillage { get; set; }
        public Nullable<int> SellFloor { get; set; }
        public Nullable<int> SellArea { get; set; }
        public Nullable<decimal> SellAreaTo { get; set; }
        public Nullable<decimal> SellPrice { get; set; }
        public Nullable<decimal> SellPriceTo { get; set; }
        public Nullable<int> SellAType { get; set; }
        public Nullable<int> SellBStructure { get; set; }
        public string SellHStructurechar { get; set; }
        public Nullable<int> SellRenovation { get; set; }
        public string SellScale { get; set; }
        public Nullable<int> SellHeating { get; set; }
        public Nullable<int> SellOrientation { get; set; }
        public Nullable<int> SellTime { get; set; }
        public Nullable<int> TransactionStatus { get; set; }
        public string NewTime { get; set; }
        public string Phone { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SalesmanID { get; set; }
        public Nullable<int> UState { get; set; }
    
        public virtual Salesman Salesman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCollection> SCollection { get; set; }
        public virtual Userd Userd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selling> Selling { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SImg> SImg { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
