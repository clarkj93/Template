﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoSell.Data.Enumerations
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name) 
        {
            (Id, Name) = (id, name);
        }

        public override string ToString() 
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                            .Select(f => f.GetValue(null))
                            .Cast<T>();
        }

        public override bool Equals(object obj)
        {
            bool result;

            if (obj is Enumeration otherValue)
            {
                var typeMatches = GetType().Equals(obj.GetType());
                var valueMatches = Id.Equals(otherValue.Id);

                result = typeMatches && valueMatches;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public int CompareTo(object other) 
        {
            return Id.CompareTo(((Enumeration)other).Id);
        } 
    }
}
