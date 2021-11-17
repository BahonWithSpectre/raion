using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Models.apiModels
{
    public class MessModel
    {
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Id отправителя
        /// </summary>
        [Required]
        public string From { get; set; }

        /// <summary>
        /// Id получателя
        /// </summary>
        [Required]
        public string To { get; set; }


        /// <summary>
        /// Дата сообщения
        /// </summary>
        [Required]
        public string MessDate { get; set; } = DateTime.Now.ToString(format: "dd.MM.yyyy HH:mm");
    }
}
