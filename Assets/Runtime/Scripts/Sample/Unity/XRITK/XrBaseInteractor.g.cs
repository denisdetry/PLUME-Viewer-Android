// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: plume/sample/unity/xritk/xr_base_interactor.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PLUME.Sample.Unity.XRITK {

  /// <summary>Holder for reflection information generated from plume/sample/unity/xritk/xr_base_interactor.proto</summary>
  public static partial class XrBaseInteractorReflection {

    #region Descriptor
    /// <summary>File descriptor for plume/sample/unity/xritk/xr_base_interactor.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static XrBaseInteractorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjFwbHVtZS9zYW1wbGUvdW5pdHkveHJpdGsveHJfYmFzZV9pbnRlcmFjdG9y",
            "LnByb3RvEhhwbHVtZS5zYW1wbGUudW5pdHkueHJpdGsaJHBsdW1lL3NhbXBs",
            "ZS91bml0eS9pZGVudGlmaWVycy5wcm90byJfChZYUkJhc2VJbnRlcmFjdG9y",
            "Q3JlYXRlEkUKCWNvbXBvbmVudBgBIAEoCzInLnBsdW1lLnNhbXBsZS51bml0",
            "eS5Db21wb25lbnRJZGVudGlmaWVyUgljb21wb25lbnQiYAoXWFJCYXNlSW50",
            "ZXJhY3RvckRlc3Ryb3kSRQoJY29tcG9uZW50GAEgASgLMicucGx1bWUuc2Ft",
            "cGxlLnVuaXR5LkNvbXBvbmVudElkZW50aWZpZXJSCWNvbXBvbmVudCKKAQoW",
            "WFJCYXNlSW50ZXJhY3RvclVwZGF0ZRJFCgljb21wb25lbnQYASABKAsyJy5w",
            "bHVtZS5zYW1wbGUudW5pdHkuQ29tcG9uZW50SWRlbnRpZmllclIJY29tcG9u",
            "ZW50Eh0KB2VuYWJsZWQYAiABKAhIAFIHZW5hYmxlZIgBAUIKCghfZW5hYmxl",
            "ZEIbqgIYUExVTUUuU2FtcGxlLlVuaXR5LlhSSVRLYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::PLUME.Sample.Unity.IdentifiersReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.XRITK.XRBaseInteractorCreate), global::PLUME.Sample.Unity.XRITK.XRBaseInteractorCreate.Parser, new[]{ "Component" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.XRITK.XRBaseInteractorDestroy), global::PLUME.Sample.Unity.XRITK.XRBaseInteractorDestroy.Parser, new[]{ "Component" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PLUME.Sample.Unity.XRITK.XRBaseInteractorUpdate), global::PLUME.Sample.Unity.XRITK.XRBaseInteractorUpdate.Parser, new[]{ "Component", "Enabled" }, new[]{ "Enabled" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class XRBaseInteractorCreate : pb::IMessage<XRBaseInteractorCreate>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<XRBaseInteractorCreate> _parser = new pb::MessageParser<XRBaseInteractorCreate>(() => new XRBaseInteractorCreate());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<XRBaseInteractorCreate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.XRITK.XrBaseInteractorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorCreate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorCreate(XRBaseInteractorCreate other) : this() {
      component_ = other.component_ != null ? other.component_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorCreate Clone() {
      return new XRBaseInteractorCreate(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as XRBaseInteractorCreate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(XRBaseInteractorCreate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(XRBaseInteractorCreate other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class XRBaseInteractorDestroy : pb::IMessage<XRBaseInteractorDestroy>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<XRBaseInteractorDestroy> _parser = new pb::MessageParser<XRBaseInteractorDestroy>(() => new XRBaseInteractorDestroy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<XRBaseInteractorDestroy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.XRITK.XrBaseInteractorReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorDestroy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorDestroy(XRBaseInteractorDestroy other) : this() {
      component_ = other.component_ != null ? other.component_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorDestroy Clone() {
      return new XRBaseInteractorDestroy(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as XRBaseInteractorDestroy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(XRBaseInteractorDestroy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(XRBaseInteractorDestroy other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class XRBaseInteractorUpdate : pb::IMessage<XRBaseInteractorUpdate>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<XRBaseInteractorUpdate> _parser = new pb::MessageParser<XRBaseInteractorUpdate>(() => new XRBaseInteractorUpdate());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<XRBaseInteractorUpdate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PLUME.Sample.Unity.XRITK.XrBaseInteractorReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorUpdate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorUpdate(XRBaseInteractorUpdate other) : this() {
      _hasBits0 = other._hasBits0;
      component_ = other.component_ != null ? other.component_.Clone() : null;
      enabled_ = other.enabled_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public XRBaseInteractorUpdate Clone() {
      return new XRBaseInteractorUpdate(this);
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 1;
    private global::PLUME.Sample.Unity.ComponentIdentifier component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::PLUME.Sample.Unity.ComponentIdentifier Component {
      get { return component_; }
      set {
        component_ = value;
      }
    }

    /// <summary>Field number for the "enabled" field.</summary>
    public const int EnabledFieldNumber = 2;
    private readonly static bool EnabledDefaultValue = false;

    private bool enabled_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Enabled {
      get { if ((_hasBits0 & 1) != 0) { return enabled_; } else { return EnabledDefaultValue; } }
      set {
        _hasBits0 |= 1;
        enabled_ = value;
      }
    }
    /// <summary>Gets whether the "enabled" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasEnabled {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "enabled" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearEnabled() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as XRBaseInteractorUpdate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(XRBaseInteractorUpdate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Component, other.Component)) return false;
      if (Enabled != other.Enabled) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (component_ != null) hash ^= Component.GetHashCode();
      if (HasEnabled) hash ^= Enabled.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (HasEnabled) {
        output.WriteRawTag(16);
        output.WriteBool(Enabled);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (component_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Component);
      }
      if (HasEnabled) {
        output.WriteRawTag(16);
        output.WriteBool(Enabled);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (component_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Component);
      }
      if (HasEnabled) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(XRBaseInteractorUpdate other) {
      if (other == null) {
        return;
      }
      if (other.component_ != null) {
        if (component_ == null) {
          Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
        }
        Component.MergeFrom(other.Component);
      }
      if (other.HasEnabled) {
        Enabled = other.Enabled;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
          case 16: {
            Enabled = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (component_ == null) {
              Component = new global::PLUME.Sample.Unity.ComponentIdentifier();
            }
            input.ReadMessage(Component);
            break;
          }
          case 16: {
            Enabled = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
