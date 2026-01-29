A simple top-down 2D survival game built with Unity and C#. The player must survive against endless waves of enemies using a rotating weapon. This project demonstrates core game development concepts, including C# Events, Prefab instantiation, and 2D physics.

## 🎮 Gameplay
* **Objective:** Survive as long as possible by avoiding enemies.
* **Combat:** A rotating axe automatically destroys enemies on contact.
* **Enemies:** Crabs spawn indefinitely. Every time a crab is defeated, a new one is spawned to take its place.
* **Game Over:** If an enemy touches the player, the player is destroyed, and the "Game Over" screen appears.

### Key Concepts
* **Event-Driven Spawning:** Uses C# `Action` delegates to create a separate loop. The `EnemyController` subscribes to each enemy's `OnDie` event to trigger the next spawn immediately.
* **Unity Events:** Uses `UnityEvent` to handle the Player's death, allowing the UI (Game Over screen) to be connected directly in the Inspector without hard-coding UI logic into the player script.
* **Physics & Movement:**
    * **Player:** Standard 2D movement.
    * **Enemies:** Vector mathematics (`Vector3.Normalize`) used to calculate direction and chase the player.
    * **Collisions:** `OnTriggerEnter2D` handles interactions between the Weapon, Enemy, and Player.
* **Randomization:** Enemies spawn at randomized positions within a specific radius using `Random.insideUnitCircle`.

## 📂 Project Structure
* **`Assets/Scripts/Player.cs`**: Handles movement input and invokes the `OnPlayerDie` event upon collision.
* **`Assets/Scripts/Enemy.cs`**: Manages pathfinding towards the player and broadcasts the `OnDie` action when hit by a weapon.
* **`Assets/Scripts/EnemyController.cs`**: Manages the initial spawn loop and listens for enemy deaths to maintain the enemy count.
* **`Assets/Scripts/WeaponRotation.cs`**: Handles the rotation logic for the player's weapon.
* **`Assets/Scripts/CloudsController.cs`**: Handles the repetition of the movement of the clouds.

## 🚀 How to Run
To examine the code and run the project locally:

1.  **Prerequisites:** Ensure you have Unity installed via Unity Hub.
2.  **Clone:** Clone this repository to your local machine.
3.  **Open:** Add the cloned folder to Unity Hub and open it.
4.  **Play:** Open `Assets/Scenes/GameScene.unity` and press the ▶️ **Play** button.
