using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;

namespace Uml.Generators;

public abstract class TextTemplate
{
    private StringBuilder builder;

    private CompilerErrorCollection errors;

    private Stack<int> indents;

    public abstract string TransformText();

    public virtual void Initialize()
    {
    }

    public virtual IDictionary<string, object> Session { get; set; }

    public StringBuilder GenerationEnvironment
    {
        get
        {
            if (builder == null) builder = new StringBuilder();
            return builder;
        }
        set => builder = value;
    }

    protected CompilerErrorCollection Errors
    {
        get
        {
            if (errors == null) errors = new CompilerErrorCollection();
            return errors;
        }
    }

    public string CurrentIndent { get; private set; } = string.Empty;

    private Stack<int> Indents
    {
        get
        {
            if (indents == null) indents = new Stack<int>();
            return indents;
        }
    }

    public ToStringInstanceHelper ToStringHelper { get; } = new();

    public void Error(string message)
    {
        Errors.Add(new CompilerError(null, -1, -1, null, message));
    }

    public void Warning(string message)
    {
        var val = new CompilerError(null, -1, -1, null, message);
        val.IsWarning = true;
        Errors.Add(val);
    }

    public string PopIndent()
    {
        if (Indents.Count == 0) return string.Empty;
        var lastPos = CurrentIndent.Length - Indents.Pop();
        var last = CurrentIndent.Substring(lastPos);
        CurrentIndent = CurrentIndent.Substring(0, lastPos);
        return last;
    }

    public void PushIndent(string indent)
    {
        Indents.Push(indent.Length);
        CurrentIndent = CurrentIndent + indent;
    }

    public void ClearIndent()
    {
        CurrentIndent = string.Empty;
        Indents.Clear();
    }

    public void Write(string textToAppend)
    {
        GenerationEnvironment.Append(textToAppend);
    }

    public void Write(string format, params object[] args)
    {
        GenerationEnvironment.AppendFormat(format, args);
    }

    public void WriteLine(string textToAppend)
    {
        GenerationEnvironment.Append(CurrentIndent);
        GenerationEnvironment.AppendLine(textToAppend);
    }

    public void WriteLine(string format, params object[] args)
    {
        GenerationEnvironment.Append(CurrentIndent);
        GenerationEnvironment.AppendFormat(format, args);
        GenerationEnvironment.AppendLine();
    }

    public class ToStringInstanceHelper
    {
        private IFormatProvider? formatProvider = CultureInfo.InvariantCulture;

        public IFormatProvider? FormatProvider
        {
            get => formatProvider;
            set
            {
                if (value != null) formatProvider = value;
            }
        }

        public string ToStringWithCulture(object objectToConvert)
        {
            if (objectToConvert == null) throw new ArgumentNullException("objectToConvert");
            var type = objectToConvert.GetType();
            var iConvertibleType = typeof(IConvertible);
            if (iConvertibleType.IsAssignableFrom(type))
                return ((IConvertible)objectToConvert).ToString(formatProvider);
            var methInfo = type.GetMethod("ToString", new[]
            {
                iConvertibleType
            });
            if (methInfo != null)
                return (string)methInfo.Invoke(objectToConvert, new object[]
                {
                    formatProvider
                });
            return objectToConvert.ToString();
        }
    }
}