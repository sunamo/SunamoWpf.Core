#define ASYNC
namespace SunamoWpf.Controls.Wrapper;

public class NotifyPropertyChangedWrapper<T> : INotifyPropertyChanged where T : DependencyObject
{
	public DependencyProperty dpIsChecked;
	public T o = default(T);
	public DependencyProperty dpContent;
	public DependencyProperty dpTag;
	public DependencyProperty dpVisibility;
	public DependencyProperty dpHeight;
	public DependencyProperty dpWidth;
	DependencyProperty capturedProperty;
	public double originalHeight = double.NaN;

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

	public bool IsActive
	{
		get { return isActive; }
		set { isActive = value;
			OnPropertyChanged("IsActive");
		}
	}


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

	public event PropertyChangedEventHandler PropertyChanged;
}