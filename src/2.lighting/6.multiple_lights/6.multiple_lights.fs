#version 330 core

struct DirLight {
    vec3 direction;
    
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct PointLight {
    vec3 position;
 
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    
    float constant;
    float linear;
    float quadratic;
};

struct SpotLight {
    vec3 position;
    vec3 direction;
    float cutOff;
    float outerCutOff;
    
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    
    float constant;
    float linear;
    float quadratic;
};

struct Material {
    sampler2D diffuse;
    sampler2D specular;
    float shininess;
};

#define NR_POINT_LIGHTS 4

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

out vec4 FragColor;

uniform DirLight dirLight;
uniform PointLight pointLights[NR_POINT_LIGHTS];
uniform SpotLight spotLight;
uniform Material material;
uniform vec3 viewPos;

vec3 calDirLight(DirLight light, vec3 norm, vec3 viewDir);
vec3 calPointLight(PointLight light, vec3 norm, vec3 fragPos, vec3 viewDir);
vec3 calSpotLight(SpotLight light, vec3 norm, vec3 fragPos, vec3 viewDir);

void main()
{
    vec3 norm = normalize(Normal);
    vec3 viewDir = normalize(FragPos - viewPos);
    
    vec3 result = calDirLight(dirLight, norm, viewDir);
    for (int i = 0; i < NR_POINT_LIGHTS; i++)
        result += calPointLight(pointLights[i], norm, FragPos, viewDir);
    result += calSpotLight(spotLight, norm, FragPos, viewDir);
    
    FragColor = vec4(result, 1.0f);
}

vec3 calDirLight(DirLight light, vec3 norm, vec3 viewDir)
{
    // ambient
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;
    
    // diffuse
    vec3 lightDir = normalize(light.direction);
    float diff = max(dot(lightDir, norm), 0.0f);
    vec3 diffuse = light.diffuse * texture(material.diffuse, TexCoords).rgb * diff;
    
    // specular
    vec3 reflectDir = normalize(reflect(-lightDir, norm));
    float spec = max(dot(viewDir, reflectDir), 0.0f);
    vec3 specular = light.specular * texture(material.specular, TexCoords).rgb * spec;
    vec3 result = ambient + diffuse + specular;
    
    return result;
}

vec3 calPointLight(PointLight light, vec3 norm, vec3 fragPos, vec3 viewDir)
{
    // ambient
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;
    
    // diffuse
    vec3 lightDir = normalize(light.position - fragPos);
    float diff = max(dot(lightDir, norm), 0.0f);
    vec3 diffuse = light.diffuse * texture(material.diffuse, TexCoords).rgb * diff;
    
    // specular
    vec3 reflectDir = normalize(reflect(-lightDir, norm));
    float spec = max(dot(viewDir, reflectDir), 0.0f);
    vec3 specular = light.specular * texture(material.specular, TexCoords).rgb * spec;
    
    float dis = length(light.position - fragPos);
    float attenuation = 1.0f / (light.constant + light.linear * dis + light.quadratic * dis * dis);
    vec3 result = (ambient + diffuse + specular) * attenuation;
    
    return result * 0.5;
}

vec3 calSpotLight(SpotLight light, vec3 norm, vec3 fragPos, vec3 viewDir)
{
    // ambient
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;
    
    // diffuse
    vec3 lightDir = normalize(light.position - fragPos);
    float diff = max(dot(lightDir, norm), 0.0f);
    vec3 diffuse = light.diffuse * texture(material.diffuse, TexCoords).rgb * diff;
    
    // specular
    vec3 reflectDir = normalize(reflect(-lightDir, norm));
    float spec = max(dot(viewDir, reflectDir), 0.0f);
    vec3 specular = light.specular * texture(material.specular, TexCoords).rgb * spec;
    
    float attenuation = 1.0f / (light.constant + light.linear + light.quadratic);
    vec3 result = (ambient + diffuse + specular) * attenuation;
    
    float theta = dot(lightDir, normalize(-light.direction));
    float intesity = clamp((theta - light.outerCutOff) / (light.cutOff - light.outerCutOff), 0.0f, 1.0f);
    result *= intesity;
    
    return result;
}
