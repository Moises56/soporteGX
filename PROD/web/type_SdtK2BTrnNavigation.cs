/*
				   File: type_SdtK2BTrnNavigation
			Description: K2BTrnNavigation
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
	[XmlRoot(ElementName="K2BTrnNavigation")]
	[XmlType(TypeName="K2BTrnNavigation" , Namespace="test" )]
	[Serializable]
	public class SdtK2BTrnNavigation : GxUserType
	{
		public SdtK2BTrnNavigation( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BTrnNavigation_Objecttolink = "";

			gxTv_SdtK2BTrnNavigation_Mode = "";

			gxTv_SdtK2BTrnNavigation_Extraparameter = "";

		}

		public SdtK2BTrnNavigation(IGxContext context)
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
			AddObjectProperty("AfterTrn", gxTpr_Aftertrn, false);


			AddObjectProperty("ObjectToLink", gxTpr_Objecttolink, false);


			AddObjectProperty("Mode", gxTpr_Mode, false);


			AddObjectProperty("ExtraParameter", gxTpr_Extraparameter, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AfterTrn")]
		[XmlElement(ElementName="AfterTrn")]
		public short gxTpr_Aftertrn
		{
			get {
				return gxTv_SdtK2BTrnNavigation_Aftertrn; 
			}
			set {
				gxTv_SdtK2BTrnNavigation_Aftertrn = value;
				SetDirty("Aftertrn");
			}
		}




		[SoapElement(ElementName="ObjectToLink")]
		[XmlElement(ElementName="ObjectToLink")]
		public string gxTpr_Objecttolink
		{
			get {
				return gxTv_SdtK2BTrnNavigation_Objecttolink; 
			}
			set {
				gxTv_SdtK2BTrnNavigation_Objecttolink = value;
				SetDirty("Objecttolink");
			}
		}




		[SoapElement(ElementName="Mode")]
		[XmlElement(ElementName="Mode")]
		public string gxTpr_Mode
		{
			get {
				return gxTv_SdtK2BTrnNavigation_Mode; 
			}
			set {
				gxTv_SdtK2BTrnNavigation_Mode = value;
				SetDirty("Mode");
			}
		}




		[SoapElement(ElementName="ExtraParameter")]
		[XmlElement(ElementName="ExtraParameter")]
		public string gxTpr_Extraparameter
		{
			get {
				return gxTv_SdtK2BTrnNavigation_Extraparameter; 
			}
			set {
				gxTv_SdtK2BTrnNavigation_Extraparameter = value;
				SetDirty("Extraparameter");
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
			gxTv_SdtK2BTrnNavigation_Objecttolink = "";
			gxTv_SdtK2BTrnNavigation_Mode = "";
			gxTv_SdtK2BTrnNavigation_Extraparameter = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtK2BTrnNavigation_Aftertrn;
		 

		protected string gxTv_SdtK2BTrnNavigation_Objecttolink;
		 

		protected string gxTv_SdtK2BTrnNavigation_Mode;
		 

		protected string gxTv_SdtK2BTrnNavigation_Extraparameter;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BTrnNavigation", Namespace="test")]
	public class SdtK2BTrnNavigation_RESTInterface : GxGenericCollectionItem<SdtK2BTrnNavigation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BTrnNavigation_RESTInterface( ) : base()
		{	
		}

		public SdtK2BTrnNavigation_RESTInterface( SdtK2BTrnNavigation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AfterTrn", Order=0)]
		public short gxTpr_Aftertrn
		{
			get { 
				return sdt.gxTpr_Aftertrn;

			}
			set { 
				sdt.gxTpr_Aftertrn = value;
			}
		}

		[DataMember(Name="ObjectToLink", Order=1)]
		public  string gxTpr_Objecttolink
		{
			get { 
				return sdt.gxTpr_Objecttolink;

			}
			set { 
				 sdt.gxTpr_Objecttolink = value;
			}
		}

		[DataMember(Name="Mode", Order=2)]
		public  string gxTpr_Mode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mode);

			}
			set { 
				 sdt.gxTpr_Mode = value;
			}
		}

		[DataMember(Name="ExtraParameter", Order=3)]
		public  string gxTpr_Extraparameter
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Extraparameter);

			}
			set { 
				 sdt.gxTpr_Extraparameter = value;
			}
		}


		#endregion

		public SdtK2BTrnNavigation sdt
		{
			get { 
				return (SdtK2BTrnNavigation)Sdt;
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
				sdt = new SdtK2BTrnNavigation() ;
			}
		}
	}
	#endregion
}