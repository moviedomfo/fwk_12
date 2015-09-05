using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;

namespace Fwk.GuidPk
{
	/// <summary>
	/// Visual Studio Helper
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
	public static class VSIPHelper
	{		
		#region Public Implementation
		/// <summary>
        ///// Gets the current selection on VS.
        ///// </summary>
        ///// <param name="provider">The service provider.</param>
        ///// <returns>The selected IVsHierarchy</returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        //public static IVsHierarchy GetCurrentSelection(IServiceProvider provider)
        //{
        //    Guard.ArgumentNotNull(provider, "provider");

        //    IVsMonitorSelection selection = (IVsMonitorSelection)provider.GetService(typeof(SVsShellMonitorSelection));
        //    IntPtr ptr1 = IntPtr.Zero;

        //    IVsMultiItemSelect vsMultiItemSelect = null;
        //    IntPtr ptr2 = IntPtr.Zero;

        //    uint pitemid;
        //    selection.GetCurrentSelection(out ptr1, out pitemid, out vsMultiItemSelect, out ptr2);
        //    if(ptr1 != IntPtr.Zero)
        //    {
        //        return (IVsHierarchy)Marshal.GetObjectForIUnknown(ptr1);
        //    }
        //    IVsHierarchy vsHierarchy = (IVsHierarchy)provider.GetService(typeof(SVsSolution));
        //    return vsHierarchy;
        //}

		/// <summary>
		/// Selects the project item.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <param name="projectItemName">Name of the project item.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
		public static void SelectProjectItem(Project project, string projectItemName)
		{
			
			SelectProjectItem(project.DTE.Solution, project.Name, projectItemName);
		}

		/// <summary>
		/// Selects the project item.
		/// </summary>
		/// <param name="solution">The solution.</param>
		/// <param name="projectName">Name of the project.</param>
		/// <param name="projectItemName">Name of the project item.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
		public static void SelectProjectItem(Solution solution, string projectName, string projectItemName)
		{
            //Guard.ArgumentNotNull(solution, "solution");
            //Guard.ArgumentNotNullOrEmptyString(projectName, "projectName");
            //Guard.ArgumentNotNullOrEmptyString(projectItemName, "projectItemName");

			UIHierarchyItem projectH = FindItemByName<Project>(
				((DTE2)solution.DTE).ToolWindows.SolutionExplorer.UIHierarchyItems, projectName);

			if(projectH != null)
			{
				UIHierarchyItem projectItemH = FindItemByName<ProjectItem>(
					 projectH.UIHierarchyItems, projectItemName);

				if(projectItemH != null)
				{
					projectItemH.Select(vsUISelectionType.vsUISelectionTypeSelect);
				}
			}
		}

		/// <summary>
		/// Finds the name of the item by.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		/// <returns></returns>

		public static ProjectItem FindItemByName(ProjectItems collection, string name, bool recursive)
		{


			foreach(ProjectItem item in collection)
			{
				if(item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return item;
				}
				if(recursive)
				{
					ProjectItem item2 = FindItemByName(item.ProjectItems, name, recursive);
					if(item2 == null)
					{
						continue;
					}
					return item2;
				}
			}

			return null;
		}

		/// <summary>
		/// Finds the first item by extension.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="extension">The extension.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
		public static ProjectItem FindFirstItemByExtension(ProjectItems collection, string extension, bool recursive)
		{
            //Guard.ArgumentNotNull(collection, "collection");
            //Guard.ArgumentNotNull(extension, "extension");

			foreach(ProjectItem item in collection)
			{
				if(Path.GetExtension(item.Name).Equals(extension, StringComparison.OrdinalIgnoreCase))
				{
					return item;
				}
				if(recursive)
				{
					ProjectItem item2 = FindFirstItemByExtension(item.ProjectItems, extension, recursive);
					if(item2 == null)
					{
						continue;
					}
					return item2;
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the file path relative.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        //public static string GetFilePathRelative(ProjectItem item)
        //{
        //    //Guard.ArgumentNotNull(item, "item");

        //    return GetFilePathRelative(item.DTE, item.get_FileNames(1));
        //}

	

        ///// <summary>
        ///// Gets the relative path.
        ///// </summary>
        ///// <param name="project">The project.</param>
        ///// <param name="projectItem">The project item.</param>
        ///// <returns></returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        //public static string GetRelativePath(Project project, ProjectItem projectItem)
        //{
        //    Guard.ArgumentNotNull(project, "project");
        //    Guard.ArgumentNotNull(projectItem, "projectItem");

        //    return GetRelativePath(project, projectItem.Properties.Item("FullPath").Value.ToString());
        //}

        ///// <summary>
        ///// Gets the relative path.
        ///// </summary>
        ///// <param name="project">The project.</param>
        ///// <param name="filePath">The file path.</param>
        ///// <returns></returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        //public static string GetRelativePath(Project project, string filePath)
        //{
        //    Guard.ArgumentNotNull(project, "project");
        //    Guard.ArgumentNotNullOrEmptyString(filePath, "filePath");

        //    string solutionRelativePath = GetFilePathRelative(project.DTE, filePath);

        //    string projectRelativePath = solutionRelativePath.Replace(project.Name + "\\", "");

        //    return projectRelativePath;
        //}

        ///// <summary>
        ///// Determines whether [is web project] [the specified project].
        ///// </summary>
        ///// <param name="project">The project.</param>
        ///// <returns>
        ///// 	<c>true</c> if [is web project] [the specified project]; otherwise, <c>false</c>.
        ///// </returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        //public static bool IsWebProject(Project project)
        //{
        //    Guard.ArgumentNotNull(project, "project");

        //    return (project.Kind.Equals(VsWebSite.PrjKind.prjKindVenusProject));
        //}
		#endregion

		#region Private Implementation
		private static UIHierarchyItem FindItemByName<TKind>(UIHierarchyItems items, string itemName)
		{
			foreach(UIHierarchyItem item in items)
			{
				if(item.Name == itemName)
				{
					return item;
				}
				else
				{
					UIHierarchyItem item2 = FindItemByName<TKind>(item.UIHierarchyItems, itemName);

					if(item2 != null)
					{
						return item2;
					}
				}
			}

			return null;
		} 
		#endregion
	}
}