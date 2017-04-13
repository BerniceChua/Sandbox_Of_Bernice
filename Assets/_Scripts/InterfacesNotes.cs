using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Interfaces = contract on functionality.
 * Any class that implements an interface must have all its methods and properties.
 * In echange, the implementing class can be treated as an interface by other classes because of polymorphism.
 * Important: interfaces are NOT classes and cannot have their own interfaces
 * 
 * Class does not inherit from an interface; class implements an interface.
 * 
 * Interfaces are declared OUTSIDE of a class.  
 * When declaring interfaces, commonly use 1 script per interface. 
 * 
 * By convention, interfaces are declared w/ capital "I" in front of the class name.  Example: "IRemovable", "IBuildable", "IDestructible", "IEnumerable".
 * Since interfaces describe some functionality that the implementing classes will have, the names end with "-able", but this is not mandatory.
 * 
 */

public interface IKillable {
    void Kill();    // any class that implements IKillable MUST have a public function which matches this signature.
}

public interface IDamageable<T> {    // this has generic type T.  means that anything in this interface can have a generic type.
    void Damage(T damageTaken);    // this takes a param of type T.
                                   // When an interface with a generic type is implemented by a class, the type MUST be chosen, then the corresponding type MUST be used throughout.
}

/* 
 * Requirements & Benefits of implementing interfaces:
 * 
 * Requirements to implement an interface = a class MUST publicly declare 
 * ALL the methods, properties, events, & indexers of the interface it implements.
 * Or else you'll get an error.
 * 
 * Advantage of interfaces = they allow you to define common functionality across many classes.
 * Therefore you're able to safely make assumptions about what classes can do based on the interfaces it implements.
 * 
 * To implement an interface, add commas after any class the class inherits from, then name of interface.
 * If class does not inherit, no need for comma.
 * If interface has a generic type, then the name should be followed by angle brackets with the type in them.
 */

// example of a class that implements an interface in "Avatar.cs".