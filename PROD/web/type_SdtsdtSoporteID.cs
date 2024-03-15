/*
				   File: type_SdtsdtSoporteID
			Description: sdtSoporteID
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
	[XmlRoot(ElementName="sdtSoporteID")]
	[XmlType(TypeName="sdtSoporteID" , Namespace="test" )]
	[Serializable]
	public class SdtsdtSoporteID : GxUserType
	{
		public SdtsdtSoporteID( )
		{
			/* Constructor for serialization */
		}

		public SdtsdtSoporteID(IGxContext context)
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
			AddObjectProperty("SoporteID", gxTpr_Soporteid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SoporteID")]
		[XmlElement(ElementName="SoporteID")]
		public int gxTpr_Soporteid
		{
			get {
				return gxTv_SdtsdtSoporteID_Soporteid; 
			}
			set {
				gxTv_SdtsdtSoporteID_Soporteid = value;
				SetDirty("Soporteid");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtsdtSoporteID_Soporteid;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtSoporteID", Namespace="test")]
	public class SdtsdtSoporteID_RESTInterface : GxGenericCollectionItem<SdtsdtSoporteID>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtSoporteID_RESTInterface( ) : base()
		{	
		}

		public SdtsdtSoporteID_RESTInterface( SdtsdtSoporteID psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SoporteID", Order=0)]
		public  string gxTpr_Soporteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Soporteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Soporteid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtsdtSoporteID sdt
		{
			get { 
				return (SdtsdtSoporteID)Sdt;
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
				sdt = new SdtsdtSoporteID() ;
			}
		}
	}
	#endregion
}