cmake_minimum_required(VERSION 3.16)

project(2.5.hello_triangle_exercise3)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} hello_triangle_exercise3.cpp)
target_link_libraries(${TARGET} PUBLIC
        ${GLAD_LIBRARY}
        ${GLFW3_LIBRARY}
        ${APPLE_LIBRARIES}
        )
target_include_directories(${TARGET} PUBLIC
        ${GLAD_INCLUDE_DIR}
        ${GLFW3_INCLUDE_DIR}
        )