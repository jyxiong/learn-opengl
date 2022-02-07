cmake_minimum_required(VERSION 3.16)

project(2.1.2.ibl_irradiance)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} ibl_irradiance.cpp)
target_link_libraries(${TARGET} PUBLIC
        ${GLAD_LIBRARY}
        ${GLFW3_LIBRARY}
        ${GLM_LIBRARY}
        ${APPLE_LIBRARIES}
        )
target_include_directories(${TARGET} PUBLIC
        ${GLAD_INCLUDE_DIR}
        ${GLFW3_INCLUDE_DIR}
        ${GLM_INCLUDE_DIR}
        ${STB_INCLUDE_DIR}
        ${CMAKE_SOURCE_DIR}/includes
        ${CMAKE_BINARY_DIR}/configuration
        )
target_compile_definitions(${TARGET} PUBLIC
        STB_IMAGE_IMPLEMENTATION
        )

# copy shader files to build directory
file(GLOB SHADERS *.vs *.fs)
foreach(SHADER ${SHADERS})
    file(COPY ${SHADER} DESTINATION ${CMAKE_BINARY_DIR}/src/${CHAPTER}/${PROJECT_NAME})
endforeach(SHADER)