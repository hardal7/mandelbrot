cmake_minimum_required(VERSION 3.5)
project(mandelbrot)
add_executable(mandelbrot ../src/main.cpp)
target_link_libraries(mandelbrot ${CMAKE_CURRENT_SOURCE_DIR}/lib/libglfw.so ${CMAKE_CURRENT_SOURCE_DIR}/lib/libglad.so)
