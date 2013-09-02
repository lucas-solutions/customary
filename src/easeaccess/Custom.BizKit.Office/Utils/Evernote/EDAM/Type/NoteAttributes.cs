/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Custom.Utils.Evernote.EDAM.Type
{

  #if !SILVERLIGHT && !NETFX_CORE
  [Serializable]
  #endif
  public partial class NoteAttributes : TBase
  {
    private long _subjectDate;
    private double _latitude;
    private double _longitude;
    private double _altitude;
    private string _author;
    private string _source;
    private string _sourceURL;
    private string _sourceApplication;
    private long _shareDate;
    private string _placeName;
    private string _contentClass;
    private LazyMap _applicationData;
    private string _lastEditedBy;
    private Dictionary<string, string> _classifications;

    public long SubjectDate
    {
      get
      {
        return _subjectDate;
      }
      set
      {
        __isset.subjectDate = true;
        this._subjectDate = value;
      }
    }

    public double Latitude
    {
      get
      {
        return _latitude;
      }
      set
      {
        __isset.latitude = true;
        this._latitude = value;
      }
    }

    public double Longitude
    {
      get
      {
        return _longitude;
      }
      set
      {
        __isset.longitude = true;
        this._longitude = value;
      }
    }

    public double Altitude
    {
      get
      {
        return _altitude;
      }
      set
      {
        __isset.altitude = true;
        this._altitude = value;
      }
    }

    public string Author
    {
      get
      {
        return _author;
      }
      set
      {
        __isset.author = true;
        this._author = value;
      }
    }

    public string Source
    {
      get
      {
        return _source;
      }
      set
      {
        __isset.source = true;
        this._source = value;
      }
    }

    public string SourceURL
    {
      get
      {
        return _sourceURL;
      }
      set
      {
        __isset.sourceURL = true;
        this._sourceURL = value;
      }
    }

    public string SourceApplication
    {
      get
      {
        return _sourceApplication;
      }
      set
      {
        __isset.sourceApplication = true;
        this._sourceApplication = value;
      }
    }

    public long ShareDate
    {
      get
      {
        return _shareDate;
      }
      set
      {
        __isset.shareDate = true;
        this._shareDate = value;
      }
    }

    public string PlaceName
    {
      get
      {
        return _placeName;
      }
      set
      {
        __isset.placeName = true;
        this._placeName = value;
      }
    }

    public string ContentClass
    {
      get
      {
        return _contentClass;
      }
      set
      {
        __isset.contentClass = true;
        this._contentClass = value;
      }
    }

    public LazyMap ApplicationData
    {
      get
      {
        return _applicationData;
      }
      set
      {
        __isset.applicationData = true;
        this._applicationData = value;
      }
    }

    public string LastEditedBy
    {
      get
      {
        return _lastEditedBy;
      }
      set
      {
        __isset.lastEditedBy = true;
        this._lastEditedBy = value;
      }
    }

    public Dictionary<string, string> Classifications
    {
      get
      {
        return _classifications;
      }
      set
      {
        __isset.classifications = true;
        this._classifications = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool subjectDate;
      public bool latitude;
      public bool longitude;
      public bool altitude;
      public bool author;
      public bool source;
      public bool sourceURL;
      public bool sourceApplication;
      public bool shareDate;
      public bool placeName;
      public bool contentClass;
      public bool applicationData;
      public bool lastEditedBy;
      public bool classifications;
    }

    public NoteAttributes() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I64) {
              SubjectDate = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.Double) {
              Latitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.Double) {
              Longitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Double) {
              Altitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.String) {
              Author = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.String) {
              Source = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.String) {
              SourceURL = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.String) {
              SourceApplication = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.I64) {
              ShareDate = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.String) {
              PlaceName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.String) {
              ContentClass = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 23:
            if (field.Type == TType.Struct) {
              ApplicationData = new LazyMap();
              ApplicationData.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 24:
            if (field.Type == TType.String) {
              LastEditedBy = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 26:
            if (field.Type == TType.Map) {
              {
                Classifications = new Dictionary<string, string>();
                TMap _map17 = iprot.ReadMapBegin();
                for( int _i18 = 0; _i18 < _map17.Count; ++_i18)
                {
                  string _key19;
                  string _val20;
                  _key19 = iprot.ReadString();
                  _val20 = iprot.ReadString();
                  Classifications[_key19] = _val20;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("NoteAttributes");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.subjectDate) {
        field.Name = "subjectDate";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(SubjectDate);
        oprot.WriteFieldEnd();
      }
      if (__isset.latitude) {
        field.Name = "latitude";
        field.Type = TType.Double;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Latitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.longitude) {
        field.Name = "longitude";
        field.Type = TType.Double;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Longitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.altitude) {
        field.Name = "altitude";
        field.Type = TType.Double;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Altitude);
        oprot.WriteFieldEnd();
      }
      if (Author != null && __isset.author) {
        field.Name = "author";
        field.Type = TType.String;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Author);
        oprot.WriteFieldEnd();
      }
      if (Source != null && __isset.source) {
        field.Name = "source";
        field.Type = TType.String;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Source);
        oprot.WriteFieldEnd();
      }
      if (SourceURL != null && __isset.sourceURL) {
        field.Name = "sourceURL";
        field.Type = TType.String;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SourceURL);
        oprot.WriteFieldEnd();
      }
      if (SourceApplication != null && __isset.sourceApplication) {
        field.Name = "sourceApplication";
        field.Type = TType.String;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SourceApplication);
        oprot.WriteFieldEnd();
      }
      if (__isset.shareDate) {
        field.Name = "shareDate";
        field.Type = TType.I64;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(ShareDate);
        oprot.WriteFieldEnd();
      }
      if (PlaceName != null && __isset.placeName) {
        field.Name = "placeName";
        field.Type = TType.String;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PlaceName);
        oprot.WriteFieldEnd();
      }
      if (ContentClass != null && __isset.contentClass) {
        field.Name = "contentClass";
        field.Type = TType.String;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ContentClass);
        oprot.WriteFieldEnd();
      }
      if (ApplicationData != null && __isset.applicationData) {
        field.Name = "applicationData";
        field.Type = TType.Struct;
        field.ID = 23;
        oprot.WriteFieldBegin(field);
        ApplicationData.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (LastEditedBy != null && __isset.lastEditedBy) {
        field.Name = "lastEditedBy";
        field.Type = TType.String;
        field.ID = 24;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(LastEditedBy);
        oprot.WriteFieldEnd();
      }
      if (Classifications != null && __isset.classifications) {
        field.Name = "classifications";
        field.Type = TType.Map;
        field.ID = 26;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Classifications.Count));
          foreach (string _iter21 in Classifications.Keys)
          {
            oprot.WriteString(_iter21);
            oprot.WriteString(Classifications[_iter21]);
            oprot.WriteMapEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("NoteAttributes(");
      sb.Append("SubjectDate: ");
      sb.Append(SubjectDate);
      sb.Append(",Latitude: ");
      sb.Append(Latitude);
      sb.Append(",Longitude: ");
      sb.Append(Longitude);
      sb.Append(",Altitude: ");
      sb.Append(Altitude);
      sb.Append(",Author: ");
      sb.Append(Author);
      sb.Append(",Source: ");
      sb.Append(Source);
      sb.Append(",SourceURL: ");
      sb.Append(SourceURL);
      sb.Append(",SourceApplication: ");
      sb.Append(SourceApplication);
      sb.Append(",ShareDate: ");
      sb.Append(ShareDate);
      sb.Append(",PlaceName: ");
      sb.Append(PlaceName);
      sb.Append(",ContentClass: ");
      sb.Append(ContentClass);
      sb.Append(",ApplicationData: ");
      sb.Append(ApplicationData== null ? "<null>" : ApplicationData.ToString());
      sb.Append(",LastEditedBy: ");
      sb.Append(LastEditedBy);
      sb.Append(",Classifications: ");
      sb.Append(Classifications);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
