/*
				   File: type_SdtDesktopNotificationInfoSDT
			Description: DesktopNotificationInfoSDT
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


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="DesktopNotificationInfoSDT")]
	[XmlType(TypeName="DesktopNotificationInfoSDT" , Namespace="test" )]
	[Serializable]
	public class SdtDesktopNotificationInfoSDT : GxUserType
	{
		public SdtDesktopNotificationInfoSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtDesktopNotificationInfoSDT_Title = "";

			gxTv_SdtDesktopNotificationInfoSDT_Message = "";

			gxTv_SdtDesktopNotificationInfoSDT_Badge = "";

			gxTv_SdtDesktopNotificationInfoSDT_Icon = "";

			gxTv_SdtDesktopNotificationInfoSDT_Tag = "";

		}

		public SdtDesktopNotificationInfoSDT(IGxContext context)
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
			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Message", gxTpr_Message, false);


			AddObjectProperty("Badge", gxTpr_Badge, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);


			AddObjectProperty("Timeout", gxTpr_Timeout, false);


			AddObjectProperty("Tag", gxTpr_Tag, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Title; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Message")]
		[XmlElement(ElementName="Message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Message; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Message = value;
				SetDirty("Message");
			}
		}




		[SoapElement(ElementName="Badge")]
		[XmlElement(ElementName="Badge")]
		public string gxTpr_Badge
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Badge; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Badge = value;
				SetDirty("Badge");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Icon; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="Timeout")]
		[XmlElement(ElementName="Timeout")]
		public short gxTpr_Timeout
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Timeout; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Timeout = value;
				SetDirty("Timeout");
			}
		}




		[SoapElement(ElementName="Tag")]
		[XmlElement(ElementName="Tag")]
		public string gxTpr_Tag
		{
			get {
				return gxTv_SdtDesktopNotificationInfoSDT_Tag; 
			}
			set {
				gxTv_SdtDesktopNotificationInfoSDT_Tag = value;
				SetDirty("Tag");
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
			gxTv_SdtDesktopNotificationInfoSDT_Title = "";
			gxTv_SdtDesktopNotificationInfoSDT_Message = "";
			gxTv_SdtDesktopNotificationInfoSDT_Badge = "";
			gxTv_SdtDesktopNotificationInfoSDT_Icon = "";

			gxTv_SdtDesktopNotificationInfoSDT_Tag = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDesktopNotificationInfoSDT_Title;
		 

		protected string gxTv_SdtDesktopNotificationInfoSDT_Message;
		 

		protected string gxTv_SdtDesktopNotificationInfoSDT_Badge;
		 

		protected string gxTv_SdtDesktopNotificationInfoSDT_Icon;
		 

		protected short gxTv_SdtDesktopNotificationInfoSDT_Timeout;
		 

		protected string gxTv_SdtDesktopNotificationInfoSDT_Tag;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"DesktopNotificationInfoSDT", Namespace="test")]
	public class SdtDesktopNotificationInfoSDT_RESTInterface : GxGenericCollectionItem<SdtDesktopNotificationInfoSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDesktopNotificationInfoSDT_RESTInterface( ) : base()
		{	
		}

		public SdtDesktopNotificationInfoSDT_RESTInterface( SdtDesktopNotificationInfoSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Title", Order=0)]
		public  string gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Message", Order=1)]
		public  string gxTpr_Message
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Message);

			}
			set { 
				 sdt.gxTpr_Message = value;
			}
		}

		[DataMember(Name="Badge", Order=2)]
		public  string gxTpr_Badge
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Badge);

			}
			set { 
				 sdt.gxTpr_Badge = value;
			}
		}

		[DataMember(Name="Icon", Order=3)]
		public  string gxTpr_Icon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Icon);

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="Timeout", Order=4)]
		public short gxTpr_Timeout
		{
			get { 
				return sdt.gxTpr_Timeout;

			}
			set { 
				sdt.gxTpr_Timeout = value;
			}
		}

		[DataMember(Name="Tag", Order=5)]
		public  string gxTpr_Tag
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tag);

			}
			set { 
				 sdt.gxTpr_Tag = value;
			}
		}


		#endregion

		public SdtDesktopNotificationInfoSDT sdt
		{
			get { 
				return (SdtDesktopNotificationInfoSDT)Sdt;
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
				sdt = new SdtDesktopNotificationInfoSDT() ;
			}
		}
	}
	#endregion
}