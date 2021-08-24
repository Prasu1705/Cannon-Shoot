// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;	// Reference to the shattered version of the Crate

		public void Destroy ()
		{
			// Spawn a shattered Crate
			GameObject destroyed = (GameObject) Instantiate(destroyedVersion, transform.position, transform.rotation);
			// Remove the current object
			Destroy(gameObject);
			Destroy(destroyed, 3f);
		}

}
