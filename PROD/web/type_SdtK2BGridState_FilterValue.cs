/*
				   File: type_SdtK2BGridState_FilterValue
			Description: FilterValues
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
	[XmlRoot(ElementName="K2BGridState.FilterValue")]
	[XmlType(TypeName="K2BGridState.FilterValue" , Namespace="test" )]
	[Serializable]
	public class SdtK2BGridState_FilterValue : GxUserType
	{
		public SdtK2BGridState_FilterValue( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BGridState_FilterValue_Filtername = "";

			gxTv_SdtK2BGridState_FilterValue_Value = "";

		}

		public SdtK2BGridState_FilterValue(IGxContext context)
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
			AddObjectProperty("FilterName", gxTpr_Filtername, false);


			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FilterName")]
		[XmlElement(ElementName="FilterName")]
		public string gxTpr_Filtername
		{
			get {
				return gxTv_SdtK2BGridState_FilterValue_Filtername; 
			}
			set {
				gxTv_SdtK2BGridState_FilterValue_Filtername = value;
				SetDirty("Filtername");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtK2BGridState_FilterValue_Value; 
			}
			set {
				gxTv_SdtK2BGridState_FilterValue_Value = value;
				SetDirty("Value");
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
			gxTv_SdtK2BGridState_FilterValue_Filtername = "";
			gxTv_SdtK2BGridState_FilterValue_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BGridState_FilterValue_Filtername;
		 

		protected string gxTv_SdtK2BGridState_FilterValue_Value;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BGridState.FilterValue", Namespace="test")]
	public class SdtK2BGridState_FilterValue_RESTInterface : GxGenericCollectionItem<SdtK2BGridState_FilterValue>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BGridState_FilterValue_RESTInterface( ) : base()
		{	
		}

		public SdtK2BGridState_FilterValue_RESTInterface( SdtK2BGridState_FilterValue psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FilterName", Order=0)]
		public  string gxTpr_Filtername
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Filtername);

			}
			set { 
				 sdt.gxTpr_Filtername = value;
			}
		}

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}


		#endregion

		public SdtK2BGridState_FilterValue sdt
		{
			get { 
				return (SdtK2BGridState_FilterValue)Sdt;
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
				sdt = new SdtK2BGridState_FilterValue() ;
			}
		}
	}
	#endregion
}