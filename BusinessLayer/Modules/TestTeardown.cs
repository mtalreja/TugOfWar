/*
 * Created by Ranorex
 * User: Mohit
 * Date: 29-08-2017
 * Time: 22:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace BusinessLayer.Modules
{
	/// <summary>
	/// Description of TestTeardown.
	/// </summary>
	[TestModule("7CDC941C-D4D3-479E-9F51-1DDCFD01581D", ModuleType.UserCode, 1)]
	public class TestTeardown : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public TestTeardown()
		{
			// Do not delete - a parameterless constructor is required!
		}

		/// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		void ITestModule.Run()
		{
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
			
			string lvUrl = TestSuite.Current.Parameters["Url"];
			CloseBroswer(lvUrl);
		}
		
		private void CloseBroswer(string pUrl)
		{
			IList<Ranorex.WebDocument> webList = Host.Local.Find<Ranorex.WebDocument>("/dom[@domain='"+ pUrl +"']");
			foreach (Ranorex.WebDocument webdoc in webList)
			{
				webdoc.Close();
			}
		}
	}
}
