cmake_minimum_required(VERSION 3.16)

project(2.1.hello_triangle)

set(TARGET_NAME ${PREFIX_FOLDER}_${PROJECT_NAME})
add_executable(${TARGET_NAME} hello_triangle.cpp)
target_link_libraries(${TARGET_NAME} PUBLIC
    ${GLAD_LIBRARY}
    ${GLFW3_LIBRARY}
    ${APPLE_LIBRARIES}
)
target_include_directories(${TARGET_NAME} PUBLIC
    ${GLAD_INCLUDE_DIR}
    ${GLFW3_INCLUDE_DIR}
)