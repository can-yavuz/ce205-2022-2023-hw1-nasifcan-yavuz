#include "myqueue.h"
#include <malloc.h>

#pragma region QUEUE FUNCTIONS
/// <summary>
/// 
/// </summary>
MyQueue* head = NULL;
MyQueue* tail = NULL;

int enqueue(MyQueue* myQueue, Data* data) {
	/// <summary>
	/// creating a linked list node
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	MyQueue* temp = (MyQueue*)malloc(sizeof(MyQueue));
	temp->data = data->key;
	temp->next = NULL;
	/// <summary>
	/// node is in front and rear when queue is empty
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	if (head == NULL && tail == NULL) {
		head = tail = temp;
		return 1;
	}
	/// <summary>
	/// adding the node at the end of queue and rear
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	tail->next = temp;
	tail = temp;
	return 1;
}
/// <summary>
/// removing an item that in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* dequeue(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	/// <summary>
	/// result is going to be null if queue is empty
	/// </summary>
	/// <param name="myQueue"></param>
	/// <returns></returns>
	if (head == NULL) {
		return NULL;
	}
	/// <summary>
	/// save previous value to front and move it to front one node ahead
	/// </summary>
	/// <param name="myQueue"></param>
	/// <returns></returns>
	if (head == tail) {
		data->key = head->data;
		head = tail = NULL;
		return data;
	}
	data->key = head->data;
	MyQueue* temp = head;
	head = head->next;
	delete(temp);
	return data;
}
/// <summary>
/// getting the front item in the queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* front(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	if (front == NULL) {
		return NULL;
	}
	data->key = head->data;
	return data;
}
/// <summary>
/// getting rear item in the queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* back(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	if (back == NULL) {
		return NULL;
	}
	data->key = tail->data;
	return data;
}
/// <summary>
/// showing all values in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
int queueLength(MyQueue* myQueue) {
	int length = 0;
	MyQueue* temp = head;
	while (temp != NULL) {
		length++;
		temp = temp->next;
	}
	return length;
}

#pragma endregion