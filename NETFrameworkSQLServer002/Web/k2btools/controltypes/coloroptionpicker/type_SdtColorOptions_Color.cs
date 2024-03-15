/*
				   File: type_SdtColorOptions_Color
			Description: ColorOptions
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
using GeneXus.Programs.k2btools.controltypes;
namespace GeneXus.Programs.k2btools.controltypes.coloroptionpicker
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="Color")]
	[XmlType(TypeName="Color" , Namespace="test" )]
	[Serializable]
	public class SdtColorOptions_Color : GxUserType
	{
		public SdtColorOptions_Color( )
		{
			/* Constructor for serialization */
			gxTv_SdtColorOptions_Color_Id = "";

			gxTv_SdtColorOptions_Color_Description = "";

			gxTv_SdtColorOptions_Color_Colorcode = "";

		}

		public SdtColorOptions_Color(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("description", gxTpr_Description, false);


			AddObjectProperty("colorCode", gxTpr_Colorcode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtColorOptions_Color_Id; 
			}
			set {
				gxTv_SdtColorOptions_Color_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtColorOptions_Color_Description; 
			}
			set {
				gxTv_SdtColorOptions_Color_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="colorCode")]
		[XmlElement(ElementName="colorCode")]
		public string gxTpr_Colorcode
		{
			get {
				return gxTv_SdtColorOptions_Color_Colorcode; 
			}
			set {
				gxTv_SdtColorOptions_Color_Colorcode = value;
				SetDirty("Colorcode");
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
			gxTv_SdtColorOptions_Color_Id = "";
			gxTv_SdtColorOptions_Color_Description = "";
			gxTv_SdtColorOptions_Color_Colorcode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtColorOptions_Color_Id;
		 

		protected string gxTv_SdtColorOptions_Color_Description;
		 

		protected string gxTv_SdtColorOptions_Color_Colorcode;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Color", Namespace="test")]
	public class SdtColorOptions_Color_RESTInterface : GxGenericCollectionItem<SdtColorOptions_Color>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtColorOptions_Color_RESTInterface( ) : base()
		{	
		}

		public SdtColorOptions_Color_RESTInterface( SdtColorOptions_Color psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="colorCode", Order=2)]
		public  string gxTpr_Colorcode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Colorcode);

			}
			set { 
				 sdt.gxTpr_Colorcode = value;
			}
		}


		#endregion

		public SdtColorOptions_Color sdt
		{
			get { 
				return (SdtColorOptions_Color)Sdt;
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
				sdt = new SdtColorOptions_Color() ;
			}
		}
	}
	#endregion
}