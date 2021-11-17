using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Models.DbModels
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        // отправитель
        [ForeignKey("FromUser")]
        public string From { get; set; }
        // получателя
        [ForeignKey("ToUser")]
        public string To { get; set; }
        public string MessageDate { get; set; }


        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}
