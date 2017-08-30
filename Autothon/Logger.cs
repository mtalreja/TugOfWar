/*
 * Created by Ranorex
 * User: IC019092
 * Date: 8/10/2016
 * Time: 2:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using Ranorex;
using Ranorex.Core.Testing;
using AppLayer;
using AppLayer.AppiumService;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Service;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace AppLayer
{
	/// <summary>
	/// Description of Logger1.
	/// </summary>
	public enum LogLevel
	{
		Always,
		Debug,
		Trace,
		Warn,
		Info,
		Success,
		Failure,
		Fatal,
		Error
	}
	
	/// <summary>
	/// Description of Logger1.
	/// </summary>
	public class Logger1
	{
		public Logger1()
		{
		}
		
		private static  ReportLevel ConvertToRanorexLevel(LogLevel logLevel)
		{
			// Don't make this dictionary static. It should only be generated if ranorex is installed on the system
			Dictionary<LogLevel, ReportLevel> dict = new Dictionary<LogLevel, ReportLevel>
			{
				{LogLevel.Always, ReportLevel.Always},
				{LogLevel.Warn, ReportLevel.Warn},
				{LogLevel.Fatal, ReportLevel.Failure},
				{LogLevel.Error, ReportLevel.Error},
				{LogLevel.Debug, ReportLevel.Debug},
				{LogLevel.Info, ReportLevel.Info},
				{LogLevel.Success, ReportLevel.Success},
				{LogLevel.Failure, ReportLevel.Failure},
				{LogLevel.Trace, ReportLevel.None}
			};
			ReportLevel reportLevel;

			if (!dict.TryGetValue(logLevel, out reportLevel))
			{
				return ReportLevel.None;
			}
			return reportLevel;
		}
		
		public static void logSnapshot(Ranorex.Core.Element element)
		{
			if(element!=null)
				Ranorex.Report.LogData(ReportLevel.Info,"",element);
			else
			{
				Ranorex.Report.LogData(ReportLevel.Info,"","");
				Report.Screenshot();
			}
			
		}
		
		public static void logSnapshot()
		{
			logSnapshot(null);
		}
		
		public static void ValidateImagesChanged(Bitmap before,Bitmap after, bool isImageChanged)
		{
			ConditionalValidation(Ranorex.Imaging.Compare( before, after)!= 1,isImageChanged,"Before and after images are different","Before and after images are same");
			Report.LogData(ReportLevel.Info,"Image Before",before);
			Report.LogData(ReportLevel.Info,"Image After",after);
		}
				
		public static void log(LogLevel logLevel, string message)
		{
			
			log(logLevel,message,false);
		}
		
		public static void log(LogLevel logLevel, string message, bool isSnapshot)
		{
			
			ReportLevel rLevel = ConvertToRanorexLevel(logLevel);
			Report.Log(rLevel,message);
			if(isSnapshot)
				Logger1.logSnapshot();
		}
		
		public static void logInfo(string message)
		{
			logInfo(message,false);
		}
		
		public static void logInfo(string message, bool isSnapshot)
		{
			Report.Info(message);
			if(isSnapshot)
				Logger1.logSnapshot();
		}
		
		public static void logSuccess(string message)
		{
			logSuccess(message,false);
		}
		
		public static void logSuccess(string message, bool isSnapshot)
		{
			Report.Success(message);
			if(isSnapshot)
				Logger1.logSnapshot();
		}
		
		public static void logFailure(string message)
		{
			logFailure(message,false);
		}
		
		public static void logFailure(string message, bool isSnapshot)
		{
			Report.Failure(message);
			if(isSnapshot)
				Logger1.logSnapshot();
		}
		
		public static void validateFailure(string message)
		{
			validateFailure(message,false);
		}
		
		public static void validateFailure(string message, bool isSnapshot)
		{
			Validate.Fail(message);
			if(isSnapshot)
				Logger1.logSnapshot();
		}
		
		public static void ConditionalValidation(bool validationLogic, bool condition,string positiveMessage,string negativeMessage)
		{
			ConditionalValidation(validationLogic,condition,positiveMessage,negativeMessage,false);
		}
		
		public static void ConditionalValidation(bool validationLogic, bool condition,string positiveMessage,string negativeMessage,bool isSnapshot)
		{
			string message=null;
			if(validationLogic==condition)
			{
				message= condition? positiveMessage:negativeMessage;
				logSuccess(message,isSnapshot);
			}
			else
			{
				message=condition? negativeMessage:positiveMessage;
				logFailure(message,isSnapshot);
			}
		}
		
	}
}
