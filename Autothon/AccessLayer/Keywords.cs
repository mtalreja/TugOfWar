/*
 * Created by Ranorex
 * User: Mohit
 * Date: 30-08-2017
 * Time: 00:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Ranorex;

namespace Autothon.AccessLayer
{
	/// <summary>
	/// Description of Keywords.
	/// </summary>
	public class Keywords
	{
		public Keywords()
		{
		}
		
		public static IList<OptionTag>  GetComboBoxElems(WebElement pInput)
		{
			return pInput.FindChildren<OptionTag>();
		}
	}
}
