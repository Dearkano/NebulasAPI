using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NebulasAPI.Data
{
    [Table("account")]
    public class Account
    {
        /// <summary>
        ///列名
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("address")]
        public string address { get; set; }
    }
}
