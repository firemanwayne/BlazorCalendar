using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Abstract
{
    public abstract class DataModelBase
    {
        protected DataModelBase()
        { }

        [Key]
        [Column(nameof(Id))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [Column(nameof(ModifiedDate))]
        public DateTime ModifiedDate { get; set; }
    }
}
