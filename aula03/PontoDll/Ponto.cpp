// Ponto.cpp : Defines the exported functions by Ponto.dll
//

#include "Ponto.h"
#include <math.h>
#include <iostream>

/*
 * This is the constructor of a class that has been exported.
 * see Ponto.h for the class definition
 */
Ponto::Ponto(int x, int y){
	this->_x = x;
	this->_y = y;
	this->_module = sqrt((double)_x*_x + _y*_y);
}

double Ponto::getModule() {	 
	return _module;
}

double Ponto::diff(Ponto * p) {
	int dx = _x - p->_x;
	int dy = _y - p->_y;
	return sqrt((double)dx*dx + dy*dy);
}


void Ponto::Print(char * label){
	printf("SUPER V1.7 %s: (x = %d, y = %d)\n", label, _x, _y);
}

