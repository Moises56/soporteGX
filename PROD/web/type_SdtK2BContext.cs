/*
				   File: type_SdtK2BContext
			Description: K2BContext
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
	[XmlRoot(ElementName="K2BContext")]
	[XmlType(TypeName="K2BContext" , Namespace="test" )]
	[Serializable]
	public class SdtK2BContext : GxUserType
	{
		public SdtK2BContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BContext_Usercode = "";

		}

		public SdtK2BContext(IGxContext context)
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
			AddObjectProperty("UserCode", gxTpr_Usercode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserCode")]
		[XmlElement(ElementName="UserCode")]
		public string gxTpr_Usercode
		{
			get {
				return gxTv_SdtK2BContext_Usercode; 
			}
			set {
				gxTv_SdtK2BContext_Usercode = value;
				SetDirty("Usercode");
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
			gxTv_SdtK2BContext_Usercode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BContext_Usercode;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BContext", Namespace="test")]
	public class SdtK2BContext_RESTInterface : GxGenericCollectionItem<SdtK2BContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BContext_RESTInterface( ) : base()
		{	
		}

		public SdtK2BContext_RESTInterface( SdtK2BContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UserCode", Order=0)]
		public  string gxTpr_Usercode
		{
			get { 
				return sdt.gxTpr_Usercode;

			}
			set { 
				 sdt.gxTpr_Usercode = value;
			}
		}


		#endregion

		public SdtK2BContext sdt
		{
			get { 
				return (SdtK2BContext)Sdt;
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
				sdt = new SdtK2BContext() ;
			}
		}
	}
	#endregion
}