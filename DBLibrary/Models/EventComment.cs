using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public abstract class BaseEvent
    {
         [Required]
          public int ID { get; set; }
        [Required]
          public string EventCommentDescription { get; set; }
        [Required]
          public string EventComentTitle { get; set; }

    }
    public class InputEventComment: BaseEvent
    {
       
        public int CommentID { get; set; }
        public int SingleEvaluation { get; set; }
        
       
         
        public long EventOcenaId { get; set; }
        
    }
    public  class EventComment : BaseEvent
    {
        public int CommentID { get; set; }
        public int SingleEvaluation { get; set; }
        public DateTime DateTime { get; set; }
        public UserInfo UserInfo { get; set; }
        public Ocena Ocena { get; set; }
    }
}
