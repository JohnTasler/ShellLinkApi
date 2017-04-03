using System;
using System.Reflection;

namespace ShellLinkApi.Framework
{
    public static class ValidateArgument
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified argument is <c>null</c>.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="message">A message that describes the error. Optional.</param>
        /// <exception cref="ArgumentNullException">Either <paramref name="parameterName"/> or <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <returns><paramref name="parameter"/></returns>
        public static T IsNotNull<T>(T argument, string argumentName, string message = null)
            where T : class
        {
            if (argumentName == null)
            {
                throw new ArgumentNullException(nameof(argumentName));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }

            return argument;
        }

        public static T IsNotNull<T>(T argument, Func<string> argumentNameCreator, Func<string> messageCreator = null)
            where T : class
        {
            if (argumentNameCreator == null)
            {
                throw new ArgumentNullException(nameof(argumentNameCreator));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(argumentNameCreator(), messageCreator != null ? messageCreator() : null);
            }

            return argument;
        }


        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the specified argument is null, or <see cref="ArgumentException"/>
        /// if the specified argument empty, or contains only whitespace.
        /// </summary>
        /// <param name="parameter">The argument.</param>
        /// <param name="parameterName">The argument name.</param>
        /// <param name="message">A message that describes the error. Optional.</param>
        /// <exception cref="ArgumentNullException">Either <paramref name="parameterName"/> or <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="parameter"/> is empty or contains only whitespace.</exception>
        /// <returns><paramref name="parameter"/></returns>
        public static string IsNotNullOrWhiteSpace(string parameter, string parameterName, string message = null)
        {
            ValidateArgument.IsNotNull(parameterName, nameof(parameterName));

            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, message);
            }
            else if (string.IsNullOrWhiteSpace(parameter))
            {
                var exceptionMessage = message ?? "Argument cannot be null, empty, or contain only whitespace.";
                throw new ArgumentException(parameterName, message);
            }

            return parameter;
        }

        public static T ImplementsInterface<T>(object parameter, string parameterName)
            where T : class
        {
            ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
            ValidateArgument.IsNotNull(parameter, parameterName);

            if (!typeof(T).GetTypeInfo().IsInterface)
            {
                var message = string.Format("Generic argument type is not an interface: {0}", typeof(T));
                throw new ArgumentException(message, nameof(T));
            }

            var result = parameter as T;
            if (result == null)
            {
                var message = string.Format("Type of argument does not implement interface type {0}: {1}", typeof(T), parameter.GetType());
                throw new ArgumentException(message, parameterName);
            }

            return result;
        }

        public static T IsOrIsDerivedFrom<T>(object parameter, string parameterName)
        {
            ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
            ValidateArgument.IsNotNull(parameter, parameterName);

            if (!(parameter is T))
            {
                var message = $"Type of argument is not equal to or derived from type {typeof(T)}: {parameter.GetType()}";
                throw new ArgumentException(message, parameterName);
            }

            return (T)parameter;
        }

        public static T IsDerivedFrom<T>(object parameter, string parameterName)
            where T : class
        {
            ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
            ValidateArgument.IsNotNull(parameter, parameterName);

            if (typeof(T) == parameter.GetType() || !(parameter is T))
            {
                var message = $"Type of argument is not derived from type ${typeof(T)}: {parameter.GetType()}";
                throw new ArgumentException(message, parameterName);
            }

            return (T)parameter;
        }
    }
}
