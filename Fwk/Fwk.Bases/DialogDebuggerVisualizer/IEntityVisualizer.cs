using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;


namespace Fwk.Bases.Debug
{

    ///// <summary>
    /////  Visualizador en modo debug para cualquier clase qeu implementa la interfaz <see cref="IEntity"/>
    ///// </summary>
    ///// <Author>Marcelo .F. Oviedo</Author>
    //public class IEntityVisualizer : DialogDebuggerVisualizer
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="windowService"></param>
    //    /// <param name="objectProvider"></param>
    //    protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
    //    {

    //        IEntity wIEntity = (IEntity)objectProvider.GetObject();

            
    //        using (IEntityVisualizerForm frm = new IEntityVisualizerForm())
    //        {
    //            frm.EntityToVisualize = wIEntity;


    //            windowService.ShowDialog(frm);
    //        }
    //    }

       
    //    /// <summary>
    //    /// Tests the visualizer by hosting it outside of the debugger.
    //    /// </summary>
    //    /// <param name="objectToVisualize">The object to display in the visualizer.</param>
    //    public static void TestShowVisualizer(object objectToVisualize)
    //    {
    //        VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(IEntityVisualizer));
    //        visualizerHost.ShowVisualizer();
            
    //    }
    //}
}