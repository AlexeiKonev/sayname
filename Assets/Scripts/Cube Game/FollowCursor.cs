using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private bool isFollowing = false; // Флаг для отслеживания нажатия кнопки мыши
    private Camera mainCamera; // Ссылка на основную камеру

    void Start()
    {
        mainCamera = Camera.main; // Получаем ссылку на основную камеру
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Если нажата левая кнопка мыши
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isFollowing = true; // Включаем режим следования за курсором только для текущего объекта
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) // Если кнопка мыши отпущена
        {
            isFollowing = false; // Выключаем режим следования
        }

        if (isFollowing) // Если включен режим следования
        {
            // Получаем позицию курсора мыши в мировых координатах
            Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(mainCamera.transform.position.z)));
            transform.position = cursorPosition; // Перемещаем объект курсору мыши
        }
    }
}
