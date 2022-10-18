#include "mystack.h"
#include <stdlib.h>

#pragma region STACK FUNCTIONS

/// <summary>
/// pushing item to the stack
/// </summary>
/// <param name="myStack"></param>
/// <param name="data"></param>
/// <returns></returns>
int push(MyStack* myStack, Data* data) {
	/// <summary>
	/// creating LL to add items
	/// </summary>
	/// <param name="myStack"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	MyStack* temp = new MyStack;
	/// <summary>
	/// adding data to LL
	/// </summary>
	/// <param name="myStack"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	temp->data = data->key;
	temp->link = myStack->link;
	myStack->link = temp;

	return 0;
}

/// <summary>
/// Pop item from stack
/// </summary>
/// <param name="myStack"></param>
/// <returns></returns>
Data* pop(MyStack* myStack) {
	if (myStack->link == NULL) {
		return NULL;
	}
	MyStack* temp = myStack->link;
	myStack->link = temp->link;
	Data* data = new Data();
	data->key = temp->data;
	delete(temp);
	return 0;
}
/// <summary>
/// Peek item from stack
/// </summary>
/// <param name="myStack"></param>
/// <returns></returns>
Data* top(MyStack* myStack)
{
	if (myStack->link == NULL) {
		return NULL;
	}
	else {
		Data* data = new Data();
		data->key = myStack->link->data;
	}
	return 0;
}
/// <summary>
/// Bottom item from stack
/// </summary>
/// <param name="myStack"></param>
/// <returns></returns>
Data* bottom(MyStack* myStack)
{
	if (myStack->link == NULL) {
		return NULL;
	}
	else {
		MyStack* temp = myStack->link;
		while (temp->link != NULL) {
			temp = temp->link;
		}
		Data* data = new Data();
		data->key = temp->data;
	}
	return 0;
}
/// <summary>
/// Display the item in stack
/// </summary>
/// <param name="myStack"></param>
/// <returns></returns>
int stackLength(MyStack* myStack) {
	int count = 0;
	MyStack* temp = myStack->link;
	/// <summary>
	/// Count items in stack
	/// </summary>
	/// <param name="myStack"></param>
	/// <returns></returns>
	while (temp != NULL) {
		count++;
		temp = temp->link;
	}
	return count;
}

#pragma endregion