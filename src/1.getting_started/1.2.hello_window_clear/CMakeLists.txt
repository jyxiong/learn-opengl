cmake_minimum_required(VERSION 3.16)

project(1.2.hello_window_clear)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} hello_window_clear.cpp)
target_link_libraries(${TARGET} PUBLIC
        glad
        glfw
        )
