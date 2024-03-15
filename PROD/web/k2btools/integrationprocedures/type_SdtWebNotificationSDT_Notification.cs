/*
				   File: type_SdtWebNotificationSDT_Notification
			Description: WebNotificationSDT
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;

using GeneXus.Programs;
using GeneXus.Programs.k2btools;
namespace GeneXus.Programs.k2btools.integrationprocedures
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="Notification")]
	[XmlType(TypeName="Notification" , Namespace="test" )]
	[Serializable]
	public class SdtWebNotificationSDT_Notification : GxUserType
	{
		public SdtWebNotificationSDT_Notification( )
		{
			/* Constructor for serialization */
			gxTv_SdtWebNotificationSDT_Notification_Notificationicon = "";
			gxTv_SdtWebNotificationSDT_Notification_Notificationicon_gxi = "";
			gxTv_SdtWebNotificationSDT_Notification_Notificationactioncaption = "";

			gxTv_SdtWebNotificationSDT_Notification_Notificationusercode = "";

			gxTv_SdtWebNotificationSDT_Notification_Notificationtext = "";

			gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtWebNotificationSDT_Notification_Eventtargeturl = "";

		}

		public SdtWebNotificationSDT_Notification(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("NotificationId", gxTpr_Notificationid, false);


			AddObjectProperty("NotificationIcon", gxTpr_Notificationicon, false);
			AddObjectProperty("NotificationIcon_GXI", gxTpr_Notificationicon_gxi, false);



			AddObjectProperty("NotificationActionCaption", gxTpr_Notificationactioncaption, false);


			AddObjectProperty("NotificationUserCode", gxTpr_Notificationusercode, false);


			AddObjectProperty("NotificationText", gxTpr_Notificationtext, false);


			datetime_STZ = gxTpr_Eventcreationdatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("EventCreationDateTime", sDateCnv, false);



			AddObjectProperty("EventTargetUrl", gxTpr_Eventtargeturl, false);


			AddObjectProperty("NotificationIsRead", gxTpr_Notificationisread, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public long gxTpr_Notificationid
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationid; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationIcon")]
		[XmlElement(ElementName="NotificationIcon")]
		[GxUpload()]

		public string gxTpr_Notificationicon
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationicon; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationicon = value;
				SetDirty("Notificationicon");
			}
		}


		[SoapElement(ElementName="NotificationIcon_GXI" )]
		[XmlElement(ElementName="NotificationIcon_GXI" )]
		public string gxTpr_Notificationicon_gxi
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationicon_gxi ;
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationicon_gxi = value;
				SetDirty("Notificationicon_gxi");
			}
		}

		[SoapElement(ElementName="NotificationActionCaption")]
		[XmlElement(ElementName="NotificationActionCaption")]
		public string gxTpr_Notificationactioncaption
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationactioncaption; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationactioncaption = value;
				SetDirty("Notificationactioncaption");
			}
		}




		[SoapElement(ElementName="NotificationUserCode")]
		[XmlElement(ElementName="NotificationUserCode")]
		public string gxTpr_Notificationusercode
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationusercode; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationusercode = value;
				SetDirty("Notificationusercode");
			}
		}




		[SoapElement(ElementName="NotificationText")]
		[XmlElement(ElementName="NotificationText")]
		public string gxTpr_Notificationtext
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationtext; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationtext = value;
				SetDirty("Notificationtext");
			}
		}



		[SoapElement(ElementName="EventCreationDateTime")]
		[XmlElement(ElementName="EventCreationDateTime" , IsNullable=true)]
		public string gxTpr_Eventcreationdatetime_Nullable
		{
			get {
				if ( gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime).value ;
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Eventcreationdatetime
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime = value;
				SetDirty("Eventcreationdatetime");
			}
		}



		[SoapElement(ElementName="EventTargetUrl")]
		[XmlElement(ElementName="EventTargetUrl")]
		public string gxTpr_Eventtargeturl
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Eventtargeturl; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Eventtargeturl = value;
				SetDirty("Eventtargeturl");
			}
		}




		[SoapElement(ElementName="NotificationIsRead")]
		[XmlElement(ElementName="NotificationIsRead")]
		public bool gxTpr_Notificationisread
		{
			get {
				return gxTv_SdtWebNotificationSDT_Notification_Notificationisread; 
			}
			set {
				gxTv_SdtWebNotificationSDT_Notification_Notificationisread = value;
				SetDirty("Notificationisread");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWebNotificationSDT_Notification_Notificationicon = "";gxTv_SdtWebNotificationSDT_Notification_Notificationicon_gxi = "";
			gxTv_SdtWebNotificationSDT_Notification_Notificationactioncaption = "";
			gxTv_SdtWebNotificationSDT_Notification_Notificationusercode = "";
			gxTv_SdtWebNotificationSDT_Notification_Notificationtext = "";
			gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtWebNotificationSDT_Notification_Eventtargeturl = "";

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected long gxTv_SdtWebNotificationSDT_Notification_Notificationid;
		 
		protected string gxTv_SdtWebNotificationSDT_Notification_Notificationicon_gxi;
		protected string gxTv_SdtWebNotificationSDT_Notification_Notificationicon;
		 

		protected string gxTv_SdtWebNotificationSDT_Notification_Notificationactioncaption;
		 

		protected string gxTv_SdtWebNotificationSDT_Notification_Notificationusercode;
		 

		protected string gxTv_SdtWebNotificationSDT_Notification_Notificationtext;
		 

		protected DateTime gxTv_SdtWebNotificationSDT_Notification_Eventcreationdatetime;
		 

		protected string gxTv_SdtWebNotificationSDT_Notification_Eventtargeturl;
		 

		protected bool gxTv_SdtWebNotificationSDT_Notification_Notificationisread;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Notification", Namespace="test")]
	public class SdtWebNotificationSDT_Notification_RESTInterface : GxGenericCollectionItem<SdtWebNotificationSDT_Notification>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWebNotificationSDT_Notification_RESTInterface( ) : base()
		{	
		}

		public SdtWebNotificationSDT_Notification_RESTInterface( SdtWebNotificationSDT_Notification psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NotificationId", Order=0)]
		public  string gxTpr_Notificationid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Notificationid, 15, 0));

			}
			set { 
				sdt.gxTpr_Notificationid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NotificationIcon", Order=1)]
		[GxUpload()]
		public  string gxTpr_Notificationicon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Notificationicon)) ? PathUtil.RelativePath( sdt.gxTpr_Notificationicon) : StringUtil.RTrim( sdt.gxTpr_Notificationicon_gxi));

			}
			set { 
				 sdt.gxTpr_Notificationicon = value;
			}
		}

		[DataMember(Name="NotificationActionCaption", Order=2)]
		public  string gxTpr_Notificationactioncaption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Notificationactioncaption);

			}
			set { 
				 sdt.gxTpr_Notificationactioncaption = value;
			}
		}

		[DataMember(Name="NotificationUserCode", Order=3)]
		public  string gxTpr_Notificationusercode
		{
			get { 
				return sdt.gxTpr_Notificationusercode;

			}
			set { 
				 sdt.gxTpr_Notificationusercode = value;
			}
		}

		[DataMember(Name="NotificationText", Order=4)]
		public  string gxTpr_Notificationtext
		{
			get { 
				return sdt.gxTpr_Notificationtext;

			}
			set { 
				 sdt.gxTpr_Notificationtext = value;
			}
		}

		[DataMember(Name="EventCreationDateTime", Order=5)]
		public  string gxTpr_Eventcreationdatetime
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Eventcreationdatetime);

			}
			set { 
				sdt.gxTpr_Eventcreationdatetime = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="EventTargetUrl", Order=6)]
		public  string gxTpr_Eventtargeturl
		{
			get { 
				return sdt.gxTpr_Eventtargeturl;

			}
			set { 
				 sdt.gxTpr_Eventtargeturl = value;
			}
		}

		[DataMember(Name="NotificationIsRead", Order=7)]
		public bool gxTpr_Notificationisread
		{
			get { 
				return sdt.gxTpr_Notificationisread;

			}
			set { 
				sdt.gxTpr_Notificationisread = value;
			}
		}


		#endregion

		public SdtWebNotificationSDT_Notification sdt
		{
			get { 
				return (SdtWebNotificationSDT_Notification)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtWebNotificationSDT_Notification() ;
			}
		}
	}
	#endregion
}