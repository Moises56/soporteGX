/*
				   File: type_SdtK2BComponentContext
			Description: K2BComponentContext
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
	[XmlRoot(ElementName="K2BComponentContext")]
	[XmlType(TypeName="K2BComponentContext" , Namespace="test" )]
	[Serializable]
	public class SdtK2BComponentContext : GxUserType
	{
		public SdtK2BComponentContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BComponentContext_Objectcontainername = "";

			gxTv_SdtK2BComponentContext_Currentcomponentname = "";

		}

		public SdtK2BComponentContext(IGxContext context)
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
			AddObjectProperty("ObjectContainerName", gxTpr_Objectcontainername, false);


			AddObjectProperty("CurrentComponentName", gxTpr_Currentcomponentname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ObjectContainerName")]
		[XmlElement(ElementName="ObjectContainerName")]
		public string gxTpr_Objectcontainername
		{
			get {
				return gxTv_SdtK2BComponentContext_Objectcontainername; 
			}
			set {
				gxTv_SdtK2BComponentContext_Objectcontainername = value;
				SetDirty("Objectcontainername");
			}
		}




		[SoapElement(ElementName="CurrentComponentName")]
		[XmlElement(ElementName="CurrentComponentName")]
		public string gxTpr_Currentcomponentname
		{
			get {
				return gxTv_SdtK2BComponentContext_Currentcomponentname; 
			}
			set {
				gxTv_SdtK2BComponentContext_Currentcomponentname = value;
				SetDirty("Currentcomponentname");
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
			gxTv_SdtK2BComponentContext_Objectcontainername = "";
			gxTv_SdtK2BComponentContext_Currentcomponentname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BComponentContext_Objectcontainername;
		 

		protected string gxTv_SdtK2BComponentContext_Currentcomponentname;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BComponentContext", Namespace="test")]
	public class SdtK2BComponentContext_RESTInterface : GxGenericCollectionItem<SdtK2BComponentContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BComponentContext_RESTInterface( ) : base()
		{	
		}

		public SdtK2BComponentContext_RESTInterface( SdtK2BComponentContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ObjectContainerName", Order=0)]
		public  string gxTpr_Objectcontainername
		{
			get { 
				return sdt.gxTpr_Objectcontainername;

			}
			set { 
				 sdt.gxTpr_Objectcontainername = value;
			}
		}

		[DataMember(Name="CurrentComponentName", Order=1)]
		public  string gxTpr_Currentcomponentname
		{
			get { 
				return sdt.gxTpr_Currentcomponentname;

			}
			set { 
				 sdt.gxTpr_Currentcomponentname = value;
			}
		}


		#endregion

		public SdtK2BComponentContext sdt
		{
			get { 
				return (SdtK2BComponentContext)Sdt;
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
				sdt = new SdtK2BComponentContext() ;
			}
		}
	}
	#endregion
}