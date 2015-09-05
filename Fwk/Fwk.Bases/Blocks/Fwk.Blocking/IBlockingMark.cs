using System;
namespace Fwk.Blocking
{
    /// <summary>
    /// Interfaz la las marcas de bloqueos.-
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public interface IBlockingMark
    {
        /// <summary>
        /// 
        /// </summary>
        Boolean AlreadyExists { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime? DueDate { get; }
        /// <summary>
        /// 
        /// </summary>
        String Process { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Guid? FwkGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Int32? BlockingId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Int32? TTL { get; set; }
        
        //Int32? BlockingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String TableName { get; }
        /// <summary>
        /// 
        /// </summary>
        string Attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AttValue { get; set; }
    }
}
