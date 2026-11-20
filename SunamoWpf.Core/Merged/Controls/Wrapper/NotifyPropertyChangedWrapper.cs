#define ASYNC
namespace SunamoWpf.Controls.Wrapper;

/// <summary>
/// Represents the notify property changed wrapper t type.
/// </summary>
public class NotifyPropertyChangedWrapper<T> : INotifyPropertyChanged where T : DependencyObject
{
	/// <summary>
	/// The dp is checked.
	/// </summary>
	public DependencyProperty dpIsChecked;
	/// <summary>
	/// The o.
	/// </summary>
	public T o = default(T);
	/// <summary>
	/// The dp content.
	/// </summary>
	public DependencyProperty dpContent;
	/// <summary>
	/// The dp tag.
	/// </summary>
	public DependencyProperty dpTag;
	/// <summary>
	/// The dp visibility.
	/// </summary>
	public DependencyProperty dpVisibility;
	/// <summary>
	/// The dp height.
	/// </summary>
	public DependencyProperty dpHeight;
	/// <summary>
	/// The dp width.
	/// </summary>
	public DependencyProperty dpWidth;
	DependencyProperty capturedProperty;
	/// <summary>
	/// The original height.
	/// </summary>
	public double originalHeight = double.NaN;

	/// <summary>
	/// The content.
	/// </summary>
	public object Content
	{
		get
		{
			return Control.GetValue(dpContent);
		}
		set
		{
			Control.SetValue(dpContent, value);
		}
	}

	private bool isActive = true;

	/// <summary>
	/// The is active.
	/// </summary>
	public bool IsActive
	{
		get { return isActive; }
		set { isActive = value;
			OnPropertyChanged("IsActive");
		}
	}


	/// <summary>
	/// The height.
	/// </summary>
	public double Height
	{
		get
		{
			return (double)Control.GetValue(dpHeight);
		}
		set
		{
			Control.SetValue(dpHeight, value);
		}
	}

	/// <summary>
	/// The visibility.
	/// </summary>
	public Visibility Visibility
	{
		get
		{
			return (Visibility)Control.GetValue(dpVisibility);
		}
		set
		{
			//if (originalHeight == double.NaN)
			//{
			//	originalHeight = Height;
			//}

			if (value == Visibility.Collapsed)
			{
				//Control.SetValue(dpHeight, 0);
				isActive = false;
			}
			else 
			{
				//Control.SetValue(dpHeight, originalHeight);
				isActive = true;
			}

			Control.SetValue(dpVisibility, value);
		}
	}

	/// <summary>
	/// The tag.
	/// </summary>
	public object Tag
	{
		get
		{
			return Control.GetValue(dpTag);
		}
		set
		{
			Control.SetValue(dpTag, value);
		}
	}

	/// <summary>
	/// The is checked.
	/// </summary>
	public bool? IsChecked
	{
		get
		{
			return (bool?)Control.GetValue(dpIsChecked);
		}
		set
		{
			Control.SetValue(dpIsChecked, value);
		}
	}

	/// <summary>
	/// The control.
	/// </summary>
	public DependencyObject Control
	{
		get
		{
			DependencyObject dependencyObject = (DependencyObject)o;
			return dependencyObject;
		}
	}

	/// <summary>
	/// A2 can be null
	/// </summary>
	/// <param name="target"></param>
	/// <param name="dependencyProperty"></param>
	public NotifyPropertyChangedWrapper(T target, DependencyProperty dependencyProperty)
	{
		this.o = target;

		if (target.GetType() == TypesControls.tCheckBox)
		{
			NotifyPropertyHelper.CheckBox<T>(this);
		}

		if (dependencyProperty != null)
		{
			this.capturedProperty = dependencyProperty;
			//this.dpIsChecked = d;
			//this.DataContext = o;

			DependencyPropertyDescriptor
				.FromProperty(dependencyProperty, typeof(T))
				.AddValueChanged(target, (sender, eventArgs) => { OnPropertyChanged(capturedProperty.Name); });
		}
	}

	void OnPropertyChanged(string propName)
	{
		PropertyChanged(this, new PropertyChangedEventArgs(propName));
	}

	/// <summary>
	/// The property changed.
	/// </summary>
	public event PropertyChangedEventHandler PropertyChanged;
}